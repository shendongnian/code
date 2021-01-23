    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                using (var container = new UnityContainer())
                {
                    container.RegisterType<IMessageProcessorClientFactory, DummyFactory>(new HierarchicalLifetimeManager());
                    container.RegisterType<IMessageClusterConfigurationStore, test>(new HierarchicalLifetimeManager());
                    container.WithFabricContainer();
                    container.WithActor<MessageClusterActor>();
                    container.WithActor<QueueListenerActor>();
                    container.WithStatelessFactory<ManagementApiServiceFactory>("ManagementApiServiceType");
                    container.WithActor<VmssManagerActor>();
                    ServiceFabricEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(ManagementApiService).Name);
                    Thread.Sleep(Timeout.Infinite);  // Prevents this host process from terminating to keep the service host process running.
                }
            }
            catch (Exception e)
            {
                ServiceFabricEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
