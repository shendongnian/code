    Action<IEnumerable<Unit>> process = null;
    var processed = new HashSet<Unit>();
    process = list => {
       foreach(var u in list.Where (processed.Add))
    	{
    		// do something here with u
    		//... and then process children
    		process(u.ChildUnits);
    	}
    };
    process(myList); // do the actual processing
