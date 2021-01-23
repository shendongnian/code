    private async Task CalculateTimeToProcess(IOwinContext context)
    {
        var sw = new Stopwatch();
        sw.Start();
        context.Response.OnSendingHeaders(state =>
        {
            sw.Stop();
            var response = (IOwinResponse)state;
            response.Headers.Add("x-timetoprocessmilliseconds", new[] { sw.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture) });
        }, context.Response);
        await Next.Invoke(context);
    }
