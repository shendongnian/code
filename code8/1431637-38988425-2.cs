    public class InstallationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
    
        public InstallationMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<InstallationMiddleware>();
        }
    
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Handling request: " + context.Request.Path);
            if (context != null && !DatabaseHelper.IsDatabaseInstalled())
            {
                if (!context.Request.Path.ToString().ToLowerInvariant().StartsWith("/installation"))
                {
                    context.Response.Redirect("/installation");
                    return;
                }
            }
                
            await _next.Invoke(context);
            _logger.LogInformation("Finished handling request.");
        }
    }
