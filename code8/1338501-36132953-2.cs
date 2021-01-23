    for(int i = 0; i < dateTimes.Length - 1; i++)
    {
        if(dateTimes[i].TimeOfDay < DateTime.Today.TimeOfDay)
        {
            return dateTimes[i + 1];
        }
    }
