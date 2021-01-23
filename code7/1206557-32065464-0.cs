    static void Main(string[] args)
    {
        //Given that previous and and now is the same day
        DateTime previous = DateTime.ParseExact("2015-08-18 10:59:41.830", "yyyy-MM-dd HH:mm:ss.fff", 
            System.Globalization.CultureInfo.InvariantCulture);
        DateTime now = DateTime.Now;
        double value = now.Subtract(previous).TotalMinutes;
        Console.WriteLine(string.Format("{0:MMMM dd}, {1} minutes ago", now, (int)value));
        Console.ReadLine();
    }
