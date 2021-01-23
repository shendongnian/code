    public abstract class RepositoryTestBase
    {
        private static IWindsorContainer windsorContainer { get; set; }
        private static IMapper mapper { get; set; }
        protected static IWindsorContainer WindsorContainer
        {
            get
            {
                if (windsorContainer == null)
                {
                    WindsorContainerManager.ConfigureWindsor(Assembly.GetExecutingAssembly());
                    windsorContainer = WindsorContainerManager.Container;
                }
                return windsorContainer;
            }
        }
        protected IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    mapper = WindsorContainer.Resolve<IMapper>();
                }
                return mapper;
            }
        }
        public static T GetResolved<T>()
        {
            return WindsorContainer.Resolve<T>();
        }
    }
        [TestFixture, Category("UnitTest")]
    public class AccountRepositoryTests : RepositoryTestBase
    {
        private IAccountRepository accountRepo = GetResolved<IAccountRepository>();
        private IContactRepository contactRepo = GetResolved<IContactRepository>();
