    private async Task<int> DoStuffAsync(CancellationTokenSource c)
    {
         return Task<int>.Run(()=> {
                int ret = 0;
                // I wanted to simulator a long running process this way
                // instead of doing Task.Delay
                for (int i = 0; i < 500000000; i++)
                {
                    ret += i;
                    if (i % 100000 == 0)
                        Console.WriteLine(i);
                    if (c.IsCancellationRequested)
                    {
                        return ret;
                    }
                }
                return ret;
            });
    }
