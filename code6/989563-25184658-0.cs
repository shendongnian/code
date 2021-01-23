    class AuditCache
    {
        public Guid ObjectId;
        public int HistoryId;
        public DateTime? DateFrom;
        public DateTime? DateTo;
        public string Value;
    };
    
    class AuditCacheComparer : IComparer<AuditCache>
    {
        public int Compare(AuditCache x, AuditCache y)
        {
            BigInteger intx = new BigInteger(x.ObjectId.ToByteArray());
            BigInteger inty = new BigInteger(y.ObjectId.ToByteArray());
            if (intx < inty)
            {
                return -1;
            }
            else if (intx > inty)
            {
                return 1;
            }
    
            return 0;
        }
    }
    
    class Program
    {
    
        static void Main(string[] args)
        {
            List<AuditCache> testCollection = new List<AuditCache>();
            Stopwatch sw = Stopwatch.StartNew();
    
            for (int i = 0; i != 1000000; ++i)
            {
                testCollection.Add(new AuditCache() { ObjectId = Guid.NewGuid(), HistoryId = i });
            }
    
            Console.WriteLine("Collection created: {0} ms", sw.ElapsedMilliseconds);
    
            AuditCacheComparer comparer = new AuditCacheComparer();
            testCollection.Sort(comparer);
    
            Console.WriteLine("Collection sorted: {0} ms", sw.ElapsedMilliseconds);
    
            for(int i = 0; i != 300000; ++ i)
            {
                var index = testCollection.BinarySearch(new AuditCache() {ObjectId = Guid.NewGuid()}, comparer);
            }
    
            Console.WriteLine("Lookup: {0} ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
