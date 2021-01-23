    class Program
    {
        public static int DoAnotherThing(string value)
        {
            return int.Parse(value);
        }
        public static async Task<string> GetValueAsync()
        {
            await Task.Delay(5000);
            return "12";
        }
        public static void DoSomethingElse()
        {
            Thread.Sleep(5000);
        }
        public static async Task<int> DoSomethingAsyncA()
        {
            DoSomethingElse();
            var result = await GetValueAsync();
            var intValue = DoAnotherThing(result);
            return intValue;
        }
        public static async Task<int> DoSomethingAsyncB()
        {
            var task = GetValueAsync();
            DoSomethingElse();
            var result = await task;
            var intValue = DoAnotherThing(result);
            return intValue;
        }
        public static void Measure(Action act)
        {
            var sw = new Stopwatch();
            sw.Start();
            act();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
        static void Main(string[] args)
        {
            Measure(() => DoSomethingAsyncA().Wait());
            Measure(() => DoSomethingAsyncB().Wait());
            Console.ReadLine();
        }
    }
