    WeekDays days = WeekDays.Monday | WeekDays.Tuesday;
    string monday = "Monday";
    WeekDays day;
    if (Enum.TryParse(monday, true, out day))
    {
        if (days.HasFlag(day))
        {
            Console.WriteLine("Has {0}", monday);
        }
        else
        {
            Console.WriteLine("Does not have {0}", monday);
        }
    }
    else
    {
        Console.WriteLine("invalid string");
    }
