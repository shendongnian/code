		public class HubContainerWrapper : IHub, IDisposable
		{
			IWindsorContainer container;
			IHub hub;
			public HubContainerWrapper (IWindsorContainer container, IHub hub)
			{
				this.container = container;
                this.hub = hub;
			}
			
			~HubContainerWrapper()
			{
				Dispose(false);
			}
			
			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			
			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (hub != null)
					{
						try
						{
							hub.Dispose();
						}
						finally
						{
							container.Release(hub);
                            container = null;
					        hub = null;
						}
					}					
				}
			}
 
            // forward all IHub calls to hub member
		}
    Then in your `IHubActivator`:
		public IHub Create(HubDescriptor descriptor)
		{
			var hubType = descriptor.HubType;
			var hub = _container.Resolve(hubType) as IHub;
			return new HubContainerWrapper(_container, hub);
		}
    This way, when SignalR disposes your hub wrapper, it will release the actual hub that you resolved from the container.
   
