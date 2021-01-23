    public class TransitReportFactory
    {
        private readonly IUnityContainer _container;
        public TransitReportFactory(IUnityContainer container)
        {
            _container = container;
        }
        ITrnsitReport Create(string reportType)
        {
            return _container.Resolve<ITrnsitReport>(reportType);
        }
    }
