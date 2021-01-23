    partial void EntryLines_Inserting(EntryLine entity)
    {
        var dow = entity.EntryDate.DayOfWeek.ToString();
        entity.Day = Days.Where(d => d.DayName == dow).SingleOrDefault();
    }
