    for(int i = 0; i < dateTimes.Length; i++)
    {
        if(dateTimes[i].TimeOfDay < DateTime.Today.TimeOfDay && i < dateTimes.Length - 1)
        {
            return dateTimes[i + 1];
        }
    }
 
