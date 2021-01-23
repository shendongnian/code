    public static Dictionary<int, string> GetDaysOfWeek()
    {
        Dictionary<int, string> daysOfWeek = new Dictionary<int, string>();
        for (int i = 0; i < 7; i++)
        {
            daysOfWeek.Add(i, Enum.GetName(typeof(DayOfWeek), i));
        }
    
        return daysOfWeek;
    }
