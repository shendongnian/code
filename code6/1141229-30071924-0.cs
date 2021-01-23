    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(DateTime.Now.AddDays(-50));
            dates.Add(DateTime.Now.AddDays(-51));
            dates.Add(DateTime.Now.AddDays(-52));
            dates.Add(DateTime.Now.AddDays(-53));
            dates.Add(DateTime.Now.AddDays(-99));
            dates.Add(DateTime.Now.AddDays(-100));
            dates.Add(DateTime.Now.AddDays(-101));
            var sev_back_datetime = DateTime.Now.AddDays(-100);
            Console.WriteLine(sev_back_datetime.Date.ToShortDateString());
            Console.WriteLine("---------------------");
            var query = from date in dates where date.Date >= sev_back_datetime.Date && date.Date <= DateTime.Now.Date select date;
            foreach (var date in query.ToList())
                Console.WriteLine(date.ToShortDateString());
            Console.ReadLine();
        }
           
    }
