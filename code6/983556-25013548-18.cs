    var result = new List<Lens>();
    var keysMoreThanOne = pairs.GroupBy(x => x.Name).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
    
    if (specidifedValue > 0)
    {
    	result = pairs.Where(x => (keysMoreThanOne.Contains(x.Name) && x.Value == specidifedValue) ||
    			!keysMoreThanOne.Contains(x.Name)).ToList();
    }
    else
    {
    	result = pairs.Where(x => (keysMoreThanOne.Contains(x.Name) && 
    		x.Value == pairs.Where(y=> y.Name==x.Name).OrderByDescending(y=> y.Value).First().Value)
    		|| !keysMoreThanOne.Contains(x.Name)).ToList();
    }
