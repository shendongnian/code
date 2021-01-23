    public BasedOnDescriptor Pick()
	{
		return BasedOn<object>();
	}
    public BasedOnDescriptor BasedOn<T>()
	{
		return BasedOn(typeof(T));
	}
    public BasedOnDescriptor BasedOn(Type basedOn)
	{
		var descriptor = new BasedOnDescriptor(basedOn, this, additionalFilters);
		criterias.Add(descriptor);
		return descriptor;
	}
