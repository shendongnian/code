    public static void Main(string[] args)
    {
        List<DateTime?> list1 = new List<DateTime?>() { null, DateTime.Parse("2014-02-12"), null, DateTime.Parse("2014-06-12"), DateTime.Parse("2014-09-12"), null, DateTime.Parse("2014-11-12")};
        List<DateTime?> list2 = new List<DateTime?>() { DateTime.Parse("2014-01-12"), null, DateTime.Parse("2014-04-12"), DateTime.Parse("2014-08-12"), null, DateTime.Parse("2014-10-12"), null };
        List<DateRange> ranges = MakeRanges(list1, list2);
        //Print out results
        foreach (var range in ranges)
        {
            Console.WriteLine(range);
        }
        var pressAKeyToExit = Console.ReadKey();
    }
