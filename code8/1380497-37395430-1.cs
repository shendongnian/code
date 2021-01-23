        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            //To add Headers AFTER everything you need to do this
            context.Response.OnStarting(state => {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("X-Response-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
                return Task.FromResult(0);
            }, context);
            await _next(context);
        }
