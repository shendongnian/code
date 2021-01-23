    private string doIt(IEnumerable<tmp> objs, params string[] g)
    {
    	var t = CollapseOrGroup(objs,g);
    
    	return JsonConvert.SerializeObject(t);
    }
    
    private dynamic CollapseOrGroup(IEnumerable<tmp> objs, IEnumerable<string> props) 
    {
    	var firstProp = props.FirstOrDefault();
    	if (firstProp == default(string))
    		return objs;
    		
    	var p = Expression.Parameter(typeof(tmp));
    	var m = Expression.Property(p, firstProp);
    	var l = Expression.Lambda(m, p).Compile() as dynamic;
    	
    	if (props.Count() == 1)
    	{
    		return Enumerable.Select(objs, l);
    		
    	} else {	
    		IEnumerable<IGrouping<dynamic, tmp>> g = Enumerable.GroupBy(objs, l);	
    		return g.ToDictionary (o => o.Key, o => CollapseOrGroup(o, props.Skip(1)));
    	}
    }
