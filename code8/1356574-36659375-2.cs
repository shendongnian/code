    class Data 
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    static void Main(string[] args)
    {
        var list = new List<Data> {
            new Data() { Date = new DateTime(2016, 10, 9, 11, 0 , 0) },
            new Data() { Date = new DateTime(2016, 10, 10, 11, 0 , 0) },
            new Data() { Date = new DateTime(2016, 10, 10, 13, 0, 0) },
            new Data() { Date = new DateTime(2016, 11, 10) },
            new Data() { Date = new DateTime(2016, 11, 11, 10, 0, 0) },
            new Data() { Date = new DateTime(2016, 11, 11, 9, 0, 0) },
        };
        var n = new DateTime(2016, 10, 10);
        var res = from data in list
                    where data.Date >= n
                    group data by new { data.Date.Year, data.Date.Month, data.Date.Day }
                    into dataGroup
                    select dataGroup.OrderBy(eg => eg.Date).Last();
        foreach (Data r in res.ToList())
        {
            Console.WriteLine(r.Date);
        }
        Console.ReadKey();
    }
