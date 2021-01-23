    static void Main(string[] args)
    {
        List<Discount> Discounts = new List<Discount>();
        Discount d1 = new Discount(new DateTime(2014, 3, 1), new DateTime(2015, 02, 28));
        Discount d2 = new Discount(new DateTime(2014, 7, 1), new DateTime(2015, 06, 30));
        Discount d3 = new Discount(new DateTime(2014, 01, 1), new DateTime(2015, 12, 31));
        Discounts.Add(d1);
        Discounts.Add(d2);
        Discounts.Add(d3);
        foreach (Discount d in Discounts)
        {
            d1.AddInterval(new DateTime(2014, 4, 1), new DateTime(2014, 11, 30));
            Console.WriteLine("IssueDate:{0} ExpirationDate:{1}", d.issueDate, d.expirationDate);
            foreach (Period p in d1.GetPeriods())
            {
                Console.WriteLine("Start:{0} End:{1}", p.StartDate, p.EndDate);
            }
        }
        
        Console.ReadLine();
    }
