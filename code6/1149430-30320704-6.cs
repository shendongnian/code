    public bool MoveNext()
    {
        int size = reeks.Count - 1;
        if (idx < size)
        {
            idx++;
            reeks.Add(reeks[size]*2);
            return true;
        }
        return false;
    }
    
