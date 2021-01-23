    public int GetNextLeapYear(int year)
    {
        if (DateTime.IsLeapYear(year))
        {
            return year;
        }
        else
        {
            year = year + 1;
            return GetNextLeapYear(year);
        }
    }
