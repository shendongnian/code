        public override async Task Invoke(IOwinContext context)
        {
            var stopwatch = new Stopwatch();
            context.Response.OnSendingHeaders(x =>
            {
                stopwatch.Stop();
                context.Response.Headers.Add("X-Processing-Time", new[] {stopwatch.ElapsedMilliseconds.ToString()});
            }, null);
            stopwatch.Start();
            await Next.Invoke(context);
            stopwatch.Stop();
        }
