    public class Program
    {
        static void Main()
        {
            DoAsyncFoo();
            Console.ReadKey();
        }
        private static async void DoAsyncFoo()
        {
            var task = CollectStatsAsync();
            dynamic foo = await task;
            Console.WriteLine(foo.NumberOfCores);
        }
        private static async Task<dynamic> CollectStatsAsync()
        {
            return CollectStats();
        }
        private static dynamic CollectStats()
        {
            return new { NumberOfCores = 3 };
        }
    }
