        IIntegratedSystem system = new IntegratedSystem(new ChannelIntegrationFactory());
    	ICustomFeature customFeature = system.GetFeature<ICustomFeature>("Which Integration?");
    	if (customFeature != null)
    	{
    		//use this custom feature
    		
    	}
    	else
    	{
    		// that's OK, will wait until is registered.
    	}
