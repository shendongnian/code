    public IEnumerable<int> GetCounts()
    {
       //get the items1 including its List of item2
       var items1 = base.Query().Include(item1 => item1.Item2s);
       
       //get the counts
       var counts = items1.Select(item1 => item1.Item2s.Select(item2 => item2.Item3Count));
       
       //now in counts you have what you want, do what you please with it
       //and return it
       return counts;
