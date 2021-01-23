    [TestClass]
    public class UnitTest1
    {
        public class TestA
        {
            public TestC valueA { get; set; }
        }
        public class TestB
        {
            public TestD valueB { get; set; }
        }
        public class TestC
        {
            public string value { get; set; }
        }
        public class TestD
        {
            public string value { get; set; }
        }
        private readonly IUnityContainer appContainer = new UnityContainer();
        public sealed class MappingConfiguration : Profile
        {
            private readonly IMappingEngine mappingEngine;
            // Inject mapping engine through constructor
            public MappingConfiguration(IMappingEngine mappingEngine)
                : base()
            {
                this.mappingEngine = mappingEngine;
            }
            protected override void Configure()
            {
                CreateMap<TestA, TestB>()
                    .ForMember(dest => dest.valueB, o => o.ResolveUsing(src => 
                        this.mappingEngine.Mapper.Map<TestD>(src.valueA)));
                CreateMap<TestC, TestD>();
            }
        }
        [TestMethod]
        public void MappingTest()
        {
            // AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(type => appContainer.Resolve(type));
            });
            var mapper = config.CreateMapper();
            appContainer.RegisterInstance<IConfiguration>(config);
            appContainer.RegisterType<IMappingEngine, MappingEngine>(new InjectionConstructor(config, mapper));
            appContainer.Resolve<IConfiguration>().AddProfile(new MappingConfiguration(appContainer.Resolve<IMappingEngine>()));
            // Check config
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            var testIn = new TestA { valueA = new TestC { value = "This is a test" } };
            var result = mapper.Map<TestB>(testIn);
        }
    }
