    public T PrepareLogbookProperty<T>(T model)
    {
    	if (model == null)
    	{
    		throw new ArgumentNullException("model");
    	}
    
    	var dynamicModel = (dynamic)model;
    
    	Entity value;
    
    	try
    	{
    		value = dynamicModel.Logbook as Logbook;
    	}
    	catch (RuntimeBinderException)
    	{
    		throw new NoLogbookPropertyFound();
    	}
    
    	value = this.PassLog(value); // THAT METHOD PASSES CURRENT USER OR DATE TIME.
    
    	dynamicModel.Logbook= value;
    
    	return model;
    }
