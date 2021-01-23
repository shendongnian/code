    int get(IEnumerable<int> array, int n)
    {
        var highest = new SortedSet<int>();
        foreach(var entry in array)
        {
            if (highest.Count < n) highest.Add(entry);
            else if(highest.Min < entry)
            {
                highest.Remove(highest.Min);
                highest.Add(entry);
            }
        }
            
        return highest.Min;
    }
