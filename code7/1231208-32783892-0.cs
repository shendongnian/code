    void Main()
    {
    	DateTime now = DateTime.Now;
    	DateTime yesterday = now.AddDays(-1);
    	TimeSpan difference = yesterday - now;
    	Console.WriteLine (difference.GetType().Name);
    	Console.WriteLine (difference.TotalSeconds); // expecting -86400
    }
