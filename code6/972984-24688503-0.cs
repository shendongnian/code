    public void TestRunLength()
    {
        var runs = new List<int>{ 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 3, 4, 4, 0, 4};
    
        var finalGroup = RunLength(runs).FirstOrDefault(i => i.Count == 6 && i.First() == 1);
    }
    
    private IEnumerable<List<int>> RunLength(IEnumerable<int> source)
    {
        int? current = null;
    
        var list = new List<int>();
    
        foreach (var i in source)
        {
            if (current == null)
            {
                current = i;
            }
    
            if (i == current)
            {
                list.Add(i);
            }
            else
            {
                yield return list;
    
                list = new List<int>{ i };
    
                current = i;
            }
        }
    
        if (list.Any())
        {
            yield return list;
        }
    }
