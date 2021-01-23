    public class MeldingssystemServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMeldingssystemService>()
                .AsWcfClient(new DefaultClientModel(WcfEndpoint.FromConfiguration("MeldingssystemService")))
                .LifeStyle.PerWebRequest.OnDestroy(service =>
                {
                    var channel = (IClientChannel) service;
                    if (channel.State == CommunicationState.Faulted)
                        channel.Abort();
                }));
        }
    }
