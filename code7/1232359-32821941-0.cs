    var o = new List<int>();
	
	if (o.GetType().IsGenericType && o is IList)
    {
		var args = o.GetType().GetGenericArguments()
		if(args.Count() == 1)
		{
			Type T = args[0];
            // rest of code
		}
	}
