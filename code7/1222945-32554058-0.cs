    public DateTime GetDate()
    {
        int day = Convert.ToInt32(date.Substring(0, 2));
        int month = Convert.ToInt32(date.Substring(3, 2));
        int year = Convert.ToInt32(date.Substring(6, 4));
        return new DateTime(year,month,day);
    }
