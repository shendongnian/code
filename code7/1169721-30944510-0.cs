    class Program
    {
        static void Main(string[] args)
        {
            int limitDays = 5;
            DateTime[] dates = 
            {
                DateTime.Now.AddDays(-1), // falls within 5 days.
                DateTime.Now.AddDays(-10) // does not fall within 5 days.
            };
            Console.WriteLine("Limit: " + DateTime.Now.AddDays(-limitDays).ToString() + " (" + limitDays.ToString() + " days)");
            Console.WriteLine();
            foreach (var date in dates)
            {
                if (DateTime.Compare(date, DateTime.Now.AddDays(-limitDays)) < 0)
                {
                    Console.WriteLine("Outside the limit: " + date.ToString());
                }
                else if (DateTime.Compare(date, DateTime.Now.AddDays(-limitDays)) >= 0)
                {
                    Console.WriteLine("Within the limit: " + date.ToString());
                }
            }
            Console.ReadLine();
        }
    }
