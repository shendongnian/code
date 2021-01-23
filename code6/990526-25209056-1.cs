    void Main()
    {
    	new Test().GetDate();
    	new Test().GetDate(start: DateTime.UtcNow);
    	new Test().GetDate(end: DateTime.UtcNow);
    	new Test().GetDate(DateTime.UtcNow, DateTime.UtcNow);
    }
