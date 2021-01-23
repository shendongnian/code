    private async Task<double> DoSomething()
    {
        return await Compute(0);
    }
    private readonly object lockObject = new object();
    private async Task<double> Compute(int input)
    {
        double result;
        lock (lockObject) {
            //This would be bad.
            result = await DoSomething();
            //So would this.  If you didn't wait inside the lock you wouldn't deadlock though.
            var t = DoSomething();
            result = t.Result;
            //This would be okay because it doesn't call back to Compute()
            using (var stream = File.OpenText("test.txt"))
            {
                var contents = await stream.ReadToEndAsync();
            }
        }
    
       return  await ComputeAsync(result).ConfigureAwait(false); // some other awaitable method
    
    }
