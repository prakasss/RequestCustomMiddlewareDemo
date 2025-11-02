using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RequestCustomMiddlewareDemo.Middleware
{
  public class RequestLoggingMiddleware
  {
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      Console.WriteLine($"[Middleware] Incoming request: {context.Request.Method} {context.Request.Path}");

      await _next(context); // Pass control to next middleware or controller

      Console.WriteLine($"[Middleware] Outgoing response: {context.Response.StatusCode}");
    }
  }

  // public static class RequestLoggingMiddlewareExtentions
  // {
  //   public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
  //   {
  //     return builder.UseMiddleware<RequestLoggingMiddleware>();
  //   }
  // }

}
