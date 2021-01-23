    public DateTime startingdate = new DateTime(2016,1,1);
    public void AddDayToDate()
    {
        var updatedDate = startingDate;
        while (true)
        {
            updatedDate = updatedDate.AddDays(1);
            print(updatedDate);
        }
    }
