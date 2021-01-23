    public static class WcfExt
    {
    	public static Task<ObservableCollection<TopologyService.ItemProperty>>
    		GetItemPropertyAsync(this ConfigurationService @this,
    			TopologyService.ItemId itemId,
    			ObservableCollection<TopologyService.ItemPropertQuery> itemPropertyCriteria)
    	{
    		return Task.Factory.FromAsync(
    			(asyncCallback, asyncState) =>
    				@this.BeginGetItemProperty(
    					itemId, itemPropertyCriteria, 
    					asyncCallback, asyncState),
    			(asyncResult) =>
    				@this.EndGetItemProperty(asyncResult), null);
    	}
    }
	// ... 
	// calling it
	try 
	{	        
		topologyItem.ItemProperties = await configurationServiceChannel.GetItemPropertyAsync(
			itemId, itemPropertyCriteria);
	}
	finally
	{
		configurationServiceChannel.Close();
	}
