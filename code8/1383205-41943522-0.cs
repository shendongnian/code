    public async Task Invoke(HttpContext context)
        {
            var timer = new Stopwatch();
            timer.Start();
            await _next(context);
           //Need to stop the timer after the pipeline finish
            timer.Stop();
            _logger.LogDebug("The request took '{0}' ms", timerer.ElapsedMilliseconds);
        }
