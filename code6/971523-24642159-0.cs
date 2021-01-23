    void Main()
    {
    	int n = NumberOfDays(DateTime.Now);
    	Console.WriteLine(n);
    }
    
    static int NumberOfDays(DateTime date)
    {
      DateTime start = DateTime.Parse("12/31/1899");
      TimeSpan t = date - start;
      return (int)t.TotalDays;
    }
