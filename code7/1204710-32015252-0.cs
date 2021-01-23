    private static MemoryCache o_Cache = MemoryCache.Default;
    static void Main(string[] args)
    {
        string cacheKey = DateTime.Today.ToString("MM/dd/yyyy");
        IEnumerable<SWFSalesModel> arrLastYearSales = GetLastYearsSalesData(o_Cache, cacheKey);
        Console.WriteLine();
        Console.WriteLine("Waiting 10 seconds...");
        Console.WriteLine();
        System.Threading.Thread.Sleep(10000);
        arrLastYearSales = GetLastYearsSalesData(o_Cache, cacheKey);
        Console.WriteLine();
        Console.WriteLine("Waiting 10 seconds...");
        Console.WriteLine();
        System.Threading.Thread.Sleep(10000);
        arrLastYearSales = GetLastYearsSalesData(o_Cache, cacheKey);
        Console.WriteLine();
        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
    private static IEnumerable<SWFSalesModel> GetLastYearsSalesData(MemoryCache o_Cache, string cacheKey)
    {
        Console.WriteLine("Looking at the cache");
        var arrLastYearsData = (IEnumerable<SWFSalesModel>)o_Cache.Get(cacheKey);
        if (arrLastYearsData != null)
        {
            return arrLastYearsData;
        }
        else
        {
            Console.WriteLine("nope, not in the cache");
            arrLastYearsData = GetLastYearSales(); ;
            CacheItemPolicy policy = new CacheItemPolicy();
            Console.WriteLine("Adding to the cache...");
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(15);
            o_Cache.Add(cacheKey, arrLastYearsData, policy);
            IEnumerable<SWFSalesModel> arrTest = (IEnumerable<SWFSalesModel>)o_Cache[cacheKey];
            if (arrTest != null)
            {
                Console.WriteLine("it's in test cache!");
            }
            else
            {
                Console.WriteLine("nope, nada in test cache");
            }
            return arrLastYearsData;
        }
    }
    // just a test
    private static IEnumerable<SWFSalesModel> GetLastYearSales()
    {
        List<SWFSalesModel> result = new List<SWFSalesModel>();
        result.Add(new SWFSalesModel());
        result.Add(new SWFSalesModel());
        result.Add(new SWFSalesModel());
        return result;
    }
