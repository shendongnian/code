    class ChannelIntegrationFactory : IChannelIntegrationFactory
    {
    	public IChannelIntegration CreateIntegration(string integrationType)
    	{
            // use integrationType to decide witch IChannelIntegration to use
    		ChannelIntegration integration = new ChannelIntegration();
    		integration.RegisterFeature<ICustomFeature>(new CustomFeature());
    		return integration;
    	}
    }
