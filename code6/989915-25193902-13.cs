    public object GetBrand(string brandName)
    {
	 	Type type;
	 	return	_Brands.TryGetValue(brandName, out type)
			? Activator.CreateInstance(type) // activator invokes a parameterless constructor
			: null; // brandName was not in the dictionary
    }
    // vs.
    return Activator.CreateInstance(null, brandName).Unwrap();
    // Case sensitivity would be an issue here.
    // Security could be an issue here.
    // Creating objects based directly off of user input means any class 
    // from any referenced assembly could be created if a hacker can learn
    // out the namespaces and class names.
