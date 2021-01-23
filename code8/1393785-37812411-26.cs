    class ChannelIntegrationFactory : IChannelIntegrationFactory
        {
        	public IChannelIntegration CreateIntegration(string integrationType)
        	{
        		IChannelIntegration integration = null;
        		switch (integrationType)
        		{
        			case "MobileIntegration":
        				integration = new MobileIntegration();
        				break;
        			case "DesktopIntegration":
        				integration = new DesktopIntegration();
        				break;
        		}
        		return integration;
        	}
        }
