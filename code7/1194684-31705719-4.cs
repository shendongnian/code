    internal class Foo
    {
        public int i;
        public long value;
        private int state = 0;
        private Task<int> task;
        int result0;
        public Task Bar()
        {
            var tcs = new TaskCompletionSource<object>();
            Action continuation = null;
            continuation = () =>
            {
                try
                {
                    if (state == 1)
                    {
                        goto state1;
                    }
                    for (i = 0; i < 10; i++)
                    {
                        Task<int> task = SomeExpensiveComputation(i);
                        var awaiter = task.GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            awaiter.OnCompleted(() =>
                            {
                                result0 = awaiter.GetResult();
                                continuation();
                            });
                            state = 1;
                            return;
                        }
                        else
                        {
                            result0 = awaiter.GetResult();
                        }
                    state1:
                        Console.WriteLine(value);
                    }
                    Console.WriteLine("Done!");
                    tcs.SetResult(true);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            };
            continuation();
        }
    }
