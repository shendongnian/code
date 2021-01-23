    int get(int[] array, int n)
    {
        var highest = new SortedSet<int>();
        for (var i = 0; i < array.Length; i++)
        {
            var entry = array[i];
            if (highest.Count < n) highest.Add(entry);
            else if (highest.Min < entry)
            {
                highest.Remove(highest.Min);
                highest.Add(entry);
            }
        }
        for(var i = 0; i < array.Length; i++)
        {
            if (array[i] == highest.Min) return i;
        }
        return -1;  //should never occur
    }
