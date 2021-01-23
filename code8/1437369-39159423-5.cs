	Record record = null;
	using(var context = new DbContext())
	{
		// Turn of lazy loading and proxy creation. 
		// Disabling one of these also should be enough.
		this.Configuration.LazyLoadingEnabled = false;
		this.Configuration.ProxyCreationEnabled = false;
		
		// Load record
		record = context.Records.FirstOrDefault(x => x.Id == id);
	}
	
	// Check for null
	if (record.XmlFormatID.HasValue && record.XmlFormat != null)
	{
	}
