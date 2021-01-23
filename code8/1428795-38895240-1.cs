    public static int GetFreshId(this IEnumerable<int> existingIds)
    {
        int i = Int32.MinValue;
        existingIds.OrderBy(id => id).TakeWhile(id => 
                {
                     if (id != i) return false;
                     i += 1;
                     
                     // check for overlow
                     if (i == Int32.MinValue)
                         throw new Exception("We ran out of IDs!");
                     return true;
                });
                 
        return i;
    }    
