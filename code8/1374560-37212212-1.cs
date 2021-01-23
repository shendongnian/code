    public Addresses GetAddress(short id)
    {
    	entityContext = new SiteDBEntities();
    	var addressList = entityContext.Addresses.Where(a => a.Id == id).FirstOrDefault();
    	
    	// Create DTO object
    	AddressesDTO address = new AddressesDTO();
    	
    	// Map it
    	address.Id = addressList.Id;
    	address.Title = addressList.Title
    	// Go on, it's quite long...
    	
    	entityContext.Dispose();
    	return address;
    }
