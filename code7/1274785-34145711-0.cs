    class Program
    {
        public static void Main(string[] args)
        {
            // Only RUN the task as needed.  FooGet 
            // still allows you to generalize your task.
            Task.Run(() =>
            {
                dynamic value = FooGet();
                value.RunSynchronously();
                Console.WriteLine(value.Result.Result.ToString());
            });
            while (true) Thread.Sleep(100);
        }
        private static Task<object> FooGet()
        {
            var task = new Task<object>(() => {
                return asyncBar();
            });
            return task;
        }
        private async static Task<object> asyncBar()
        {
            // do work!
            return "Hello, world!";
        }
    }
