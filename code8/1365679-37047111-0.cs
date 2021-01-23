    protected override void OnChildChanged(ChildChangedEventArgs e)
    {
    	base.OnChildChanged(e);
    
    	// We are only interested in some change in a List property
    	if (e.ListChangedArgs == null || e.ChildObject == null) return;
    
    	// We are only interested in addition or removal from list
    	if (e.ListChangedArgs.ListChangedType != ListChangedType.ItemAdded
    		&& e.ListChangedArgs.ListChangedType != ListChangedType.ItemDeleted)
    		return;
    
    	// Find property by type
    	var t = e.ChildObject.GetType();
    	var prop = FieldManager.GetRegisteredProperties().FirstOrDefault(p => p.Type == t);
    
    	// Raise property change, which in turn calls BusinessRules.CheckRules on specified property
    	foreach (prop != null)
    		PropertyHasChanged(prop);
    }
