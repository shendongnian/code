    public class TransitReportFactory : ITransitReportFactory
    {
        private readonly IUnityContainer _container;
        public TransitReportFactory(IUnityContainer container) // container is injected automatically.
        {
            _container = container;
        }
        ITrnsitReport Create(string reportType)
        {
            return _container.Resolve<ITrnsitReport>(reportType);
        }
    }
