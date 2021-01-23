    List<int> MetCriteria = new List<int>();
    Parallel.ForEach(dt.AsEnumerable(), (entry, state) =>
    {
        if (Convert.ToInt32(entry["Time"]) > 100)//in miliseconds
        {
            lock (MetCriteria)
            {
                MetCriteria.Add(Convert.ToInt32(entry["EntryID"]));
            }
        }
    });
