    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(0, ex, "An unhandled exception has occurred while executing the request");
            if (context.Response.HasStarted)
            {
                _logger.LogWarning("The response has already started, the error page middleware will not be executed.");
                throw;
            }
            try
            {
                context.Response.Clear();
                context.Response.StatusCode = 500;
                await DisplayException(context, ex);
                if (_diagnosticSource.IsEnabled("Microsoft.AspNetCore.Diagnostics.UnhandledException"))
                {
                    _diagnosticSource.Write("Microsoft.AspNetCore.Diagnostics.UnhandledException", new { httpContext = context, exception = ex });
                }
                return;
            }
            catch (Exception ex2)
            {
                // If there's a Exception while generating the error page, re-throw the original exception.
                _logger.LogError(0, ex2, "An exception was thrown attempting to display the error page.");
            }
            throw;
        }
    }
