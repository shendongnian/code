     class Program
    {
        static void Main(string[] args)
        {
            var dateTimes = new[]
            {
                new DateTime(2016, 06, 29 ),
                new DateTime(2016, 06, 27 ),
                new DateTime(2016, 05, 05 ),
                new DateTime(2016, 04, 15 ),
                new DateTime(2016, 04, 13 )
            };
            var bob = dateTimes.GroupBy(x => x.Year).OrderByDescending(x => x.Key);
            foreach (IGrouping<int, DateTime> grouping in bob)
            {
                var months = grouping.GroupBy(x => x.Month);
                foreach (IGrouping<int, DateTime> month in months)
                {
                    Console.WriteLine(month.First());
                }
            }
            Console.ReadLine();
        }
    }
