    public DateTime startingdate = new DateTime(2016,1,1);
    public void AddDayToDate()
    {
        while (true)
        {
            startingdate = startingdate.AddDays(1);
            print(startingdate);
        }
    }
