    public int GetNextLeapYear(int year)
    {
        while (true)
        {
            if (DateTime.IsLeapYear(year))
            {
                return year;
            }
            year = year + 1;
        }
    }
