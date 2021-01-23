    foreach(DateTime date in dateTimes)
    {
        if(!(date.TimeOfDay < DateTime.Today.TimeOfDay))
        {
            continue;
        }
        return date;
    }
