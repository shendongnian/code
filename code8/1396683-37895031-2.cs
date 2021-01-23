    static decimal GetStats(IEnumerable<Employee> g)
    {
        decimal sum = 0;
        decimal prev = 0;
        int index = 0;
        foreach (var e in g)
        {
        	sum = (index < 2 ? 0 : sum) + Math.Abs(e.Stats - prev);
        	prev = e.Stats;
        	index++;        
        }
        return sum;
    }
