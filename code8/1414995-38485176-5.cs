    var defDoctTypeDict = context.DEFDOCTYPE.AsNoTracking().ToList().ToDictionary(x => x.ID);
    
    foreach(var item in Doc)
    {
    	DEFDOCTYPE micsysserviceName;
    	
    	defDoctTypeDict.TryGetValue(item.DOCTYPE, out micsysserviceName);
    	if(micsysserviceName != null)
    	{
    		// ...code...
    	}
    	
    	// ...code...
    }
