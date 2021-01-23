    private IEnumerable<Worker> GetWorkers()
    {
    	var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
    	var fields = GetType().GetFields(flags);
    	var fieldValues = fields.Select(f => f.GetValue(this)).Cast<Worker>();
    	
    	var properties = GetType().GetProperties(flags);
    	var propertyValues = properties.Select(f => f.GetValue(this)).Cast<Worker>();
    	
    	return fieldValues.Concat(propertyValues).Where(w => w != null);
    }
    
    private bool CheckForWorkers() 
    {
        return GetWorkers().Any(w => w.IsBusy);
    }
