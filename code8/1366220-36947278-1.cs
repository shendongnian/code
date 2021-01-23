    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestHandlerMiddleware>();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
    public class RequestHandlerMiddleware
    {
        RequestDelegate _next;
        public RequestHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var handler = new RequestHandler();
            await handler.HandleRequestAsync(context);
            await _next.Invoke(context); // invoke the next delegate in the pipeline
        }
    }
    public class RequestHandler
    {
        private string Output = "";
        public async Task HandleRequestAsync(HttpContext context)
        {
            Output += context.Request.Path + "\n";
            await context.Response.WriteAsync(Output);
        }
    }
