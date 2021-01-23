    class ChannelIntegrationFactory : IChannelIntegrationFactory
    {
    	public IChannelIntegration CreateIntegration(string integrationType)
    	{
    		IChannelIntegration integration = null;
    		switch (integrationType)
    		{
    			case "MobileIntegration":
    				integration = new ChannelIntegration();
    				integration.Register<ITapGestureTrack>(new TapGestureTrack());
    				break;
    			case "DesktopIntegration":
    				integration = new ChannelIntegration();
    				integration.Register<IClickTrack>(new ClickTracker());
    				integration.Register<ILargeImagesProvider>(new LargeImagesProvider());
    				break;
    		}
    		return integration;
    	}
    }
