    var result = list.Aggregate(
    	Enumerable.Repeat(new { Name = default(string), Count = default(int) }, 0).ToList(),
    	(res, name) =>
    	{
    		int last = res.Count - 1;
    		if (last >= 0 && res[last].Name == name)
    			res[last] = new { Name = name, Count = res[last].Count + 1 };
    		else
    			res.Add(new { Name = name, Count = 1 });
    		return res;
    	});
