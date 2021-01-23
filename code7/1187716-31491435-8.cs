    public class CoreServicesFacade : ICoreServicesFacade
    {
        private readonly ILocalizer localizer;
        public ILocalizer Localizer { get { return localizer; } }
        public CoreServices(ILocalizerFactory localizerFactory, ...)
        {
            if(localizer==null)
                throw new ArgumentNullException("localizerFactory");
            this.localizer = localizerFactory.Create( Application.Current.Resources, Application.Current.ToString().Split('.')[0]);
        }
    }
