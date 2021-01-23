    public class Cached<FromT, ToT>
    {
        private Func<FromT, ToT> _my_func;
        private static ConcurrentDictionary<FromT, ToT> funcDict = new ConcurrentDictionary<FromT, ToT>();
        public Cached(Func<FromT, ToT> coreFunc)
        {
            _my_func = coreFunc;
        }
    
        private ToT TryGetValue(FromT fromKey)
        {
            ToT answer;
            funcDict.TryGetValue(fromKey, out answer);
            return answer;
        }
    
        public Task<ToT> Get(FromT fromKey)
        {            
            if (!funcDict.ContainsKey(fromKey))            
                return Task.Factory.StartNew(() => {
                    funcDict.TryAdd(fromKey, _my_func(fromKey));                    
                    return TryGetValue(fromKey);
                });            
            return Task.FromResult(TryGetValue(fromKey));
        }
    }
    
    public static string DBSimulation(int example)
    {
        Thread.Sleep(15000);
        return example.ToString();
    }
    
    public static void Main()
    {
        var testCache = new Cached<int, string>(x => DBSimulation(x));
        DateTime checkNow = DateTime.Now;
        for (int i = 0; i < 24; i++)
        {
            var j = i;
            testCache.Get(i % 3).ContinueWith(x => 
                Console.WriteLine(String.Format("After {0} seconds => {1} returned from {2} \n",
                                           ((TimeSpan)(DateTime.Now - checkNow)).TotalSeconds,
                                           x.Result, j))
            );
        }            
        Console.ReadKey();        
    }
