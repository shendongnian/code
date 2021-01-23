[DependsOn(typeof(AbpWebApiModule), typeof(ShopApplicationModule))]
public class ShopWebApiModule : AbpModule {
    public override void Initialize()
    {
       IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
       Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            .ForAll<IApplicationService>(Assembly.GetAssembly(typeof(ShopApplicationModule)), "app")
            .Build();
        }
    }
