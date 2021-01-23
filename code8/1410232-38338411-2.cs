    public int GetNextLeapYear(int year)
    {
        if (!DateTime.IsLeapYear(year))
        {
            return GetNextLeapYear(year + 1);
        }
        return year;
    }
