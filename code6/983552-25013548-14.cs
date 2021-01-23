    var result = new List<Lens>();
    
    if (specidifedValue > 0)
    {
    	var keysMoreThanOne = pairs.GroupBy(x => x.Name).Where(x => x.Count() > 1).Select(x => x.Key).ToList();
    
    	result = pairs.Where(x => (keysMoreThanOne.Contains(x.Name) && x.Value == specidifedValue) ||
    			!keysMoreThanOne.Contains(x.Name)).ToList();
    }
    else
    {
    	result = pairs.GroupBy(x => x.Name)
    	  .Select(x => new Lens(x.Key, x.Max(y => y.Value)))
    	  .ToList();
    }
