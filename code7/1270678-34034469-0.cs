    public class ModelContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAttachmentService, AttachmentService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IBrxxgeService, BrxxgeService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ICaxxxxociationService, CaxxxxociationService>(new ContainerControlledLifetimeManager());            
            Container.RegisterType<ITraxxxacityService, TraxxxcityService>(new ContainerControlledLifetimeManager());
        }
    }
    public partial class DClearanceService : ServiceBase
    {
        private UnityContainer _container = new UnityContainer();
    
        public DimensionalClearanceService()
        {
            InitializeComponent();
            ExceptionHandlingManager.InitializeExceptionManager();
    
            _container.AddExtension(new ModelContainerExtension());
        }
