    var list = heights.ToList();
    list.Sort((a,b) => {return a.Value.CompareTo(b.Value);});
    bool first = true;
    for (int i = 1; i < list.Count; ++i)
    {
    	if (Math.Abs(list[i-1].Value - list[i].Value) < threshold)
    	{
    		if (first)
    		{
    			first = false;
    			Console.WriteLine(list[i-1]);
    		}
    		Console.WriteLine(list[i]);
    	}
    }
