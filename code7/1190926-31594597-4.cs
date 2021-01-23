    if (line.Contains(searchables[i]))
    {
        if (counters.ContainsKey(searchables[i]))
        {
            counters[searchables[i]] ++;
        }
        else
        {
            counters.Add(searchables[i], 1);
        }
    }
 
