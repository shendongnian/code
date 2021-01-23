    for (int i = 0; i < list.Count; i++)
    {
        var m = list[i];
        list[i] = new DateTime(date.Year, date.Month, date.Day, m.Hour, m.Minute, m.Second);
    }
