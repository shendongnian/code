    class IntegratedSystem : IIntegratedSystem
    {
    	private IChannelIntegrationFactory integrationFactory;
    	public IntegratedSystem(IChannelIntegrationFactory integrationFactory)
    	{
    		this.integrationFactory = integrationFactory;
    	}
        public T GetFeature<T>(string integrationType) where T: IIntegrationFeature
	  {
		IChannelIntegration integration = integrationFactory.CreateIntegration(integrationType);
		var feature = integration.GetFeature<T>();
		return feature;
	  }
    }
