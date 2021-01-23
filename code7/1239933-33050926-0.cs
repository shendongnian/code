    static List<object> GetBigObjectList()
    {
        var list = new List<object>();
        for (int i = 0; i < 10000; i++)
        {
            list.Add(new object());
        }
        return list;
    }
    static void Main(string[] args)
    {
        var myList = GetBigObjectList();
        var s1 = new Stopwatch();
        var s2 = new Stopwatch();
        var s3 = new Stopwatch();
        s1.Start();
        for (int i = 0; i < 100000; i++)
        {
            var isNotEqual = myList.Count != 0;
        }
        s1.Stop();
        s2.Start();
        for (int i = 0; i < 100000; i++)
        {
            var isGreaterThan = myList.Count > 0;
        }
        s2.Stop();
        s3.Start();
        for (int i = 0; i < 100000; i++)
        {
            var isAny = myList.Any();
        }
        s3.Stop();
        Console.WriteLine("Time taken by !=    : " + s1.ElapsedMilliseconds);
        Console.WriteLine("Time taken by >     : " + s2.ElapsedMilliseconds);
        Console.WriteLine("Time taken by Any() : " + s3.ElapsedMilliseconds);            
        Console.ReadLine();
    }
