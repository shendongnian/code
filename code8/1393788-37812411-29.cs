       class IntegratedSystem : IIntegratedSystem
    {
    	private IChannelIntegrationFactory integrationFactory;
    	public IntegratedSystem(IChannelIntegrationFactory integrationFactory)
    	{
    		this.integrationFactory = integrationFactory;
    	}
    	public T GetFeature<T>(string integrationType) where T: IIntegrationFeature
    	{
    		T integrationFeature = default(T);
    		IChannelIntegration integration = integrationFactory.CreateIntegration(integrationType);
    		if (integration != null)
    		{
    			integrationFeature = (T)integration.GetFeature<T>();	
    		}
    		return integrationFeature;
    	}
    }
