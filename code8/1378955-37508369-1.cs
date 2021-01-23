    [DependsOn(typeof(MyProjectCoreModule), typeof(AbpAutoMapperModule))]
    public class MyProjectApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            // --- MY CODE for registering custom automapping
            var mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MyProjectMapperProfile());  // &lt;= here my custom mapping
            });
            var mapper = mapperConfiguration.CreateMapper();
            IocManager.IocContainer.Register(
                    Castle.MicroKernel.Registration.Component.For&lt;IMapper>().Instance(mapper)
                );
            // --- MY CODE
        }
    }
