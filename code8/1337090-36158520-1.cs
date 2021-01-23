    public class AsynchronousCachingSample
    {
        private static async Task<string> SomeLongRunningOperation()
        {
            Console.WriteLine("I'm starting a long running operation");
            await Task.Delay(1000);
            return "Result";
        }
    
        private static ConcurrentDictionary<string, string> resultCache =
            new ConcurrentDictionary<string, string>();
        private static async Task<string> CacheResult(string key)
        {
            string output;
            if (!resultCache.TryGetValue(key, out output))
            {
                output = await SomeLongRunningOperation();
                resultCache.TryAdd(key, output);
            }
            return output;
        }
    
        private static ConcurrentDictionary<string, Task<string>> taskCache =
            new ConcurrentDictionary<string, Task<string>>();
        private static Task<string> CacheTask(string key)
        {
            Task<string> output;
            if (!taskCache.TryGetValue(key, out output))
            {
                output = SomeLongRunningOperation();
                taskCache.TryAdd(key, output);
            }
            return output;
        }
    
        public static async Task Test()
        {
            int repetitions = 5;
            Console.WriteLine("Using result caching:");
            await Task.WhenAll(Enumerable.Repeat(false, repetitions)
                  .Select(_ => CacheResult("Foo")));
    
            Console.WriteLine("Using task caching:");
            await Task.WhenAll(Enumerable.Repeat(false, repetitions)
                  .Select(_ => CacheTask("Foo")));
        }
    }
