    for (int i = 0; i < data.noevents; i++)
    {
        int t = (int)(rg.Next(1, 45));
        Console.WriteLine(t);
        if (timeslot_events.ContainsKey(t))
        {
            if (timeslot_events[t] == null)
            {
                timeslot_events[t] = new List<int>();
            }
            timeslot_events[t].Add(i);
        }
        else
        {
            timeslot_events.Add(t, new List<int>() { i });
        }   
    
    }
