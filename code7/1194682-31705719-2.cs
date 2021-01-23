    internal class Foo //this represents a compiler generated class with 
    //a name that won't be a valid C# identifier.
    {
        public int i;
        public long value;
        private int state = 0;
        private Task<int> task;
        int result0;
        public void Bar()
        {
            Action continuation = null;
            continuation = () =>
            {
                if (state == 1)
                {
                    goto state1;
                }
                for (i = 0; i < 10; i++)
                {
                    Task<int> task = SomeExpensiveComputation(i);
                    var awaiter = task.GetAwaiter();
                    awaiter.OnCompleted(() =>
                    {
                        result0 = awaiter.GetResult();
                        continuation();
                    });
                    state = 1;
                    return;
                state1:
                    Console.WriteLine(value);
                }
                Console.WriteLine("Done!");
            };
        }
    }
