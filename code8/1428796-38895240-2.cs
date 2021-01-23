    public static int GetFreshId(this IEnumerable<int> existingIds)
    {
        int i = Int32.MinValue;
        foreach(int id in existingIds.OrderBy(id => id))
        {
            if (id != i) return i;
            if (i == Int32.MaxValue)
                throw new Exception("We ran out of IDs!");
            i += 1;
        }
        
        return i; // this now one more than the last/biggest existing ID
    }
