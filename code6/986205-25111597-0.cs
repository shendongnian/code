    public class MvcApplication : System.Web.HttpApplication
    {
    protected void Application_Start()
    {
    AreaRegistration.RegisterAllAreas();
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    ModuleViewEnginsConfig.RegisterAllEngins();
    CustomValidatorsConfig.Register();
    DependencyConfigure.Initialize();
    
            ModelBinderProviders.BinderProviders.Add(new YourModelBinderProvider());
    
            var dirs = System.IO.Directory.GetFiles(Server.MapPath("~/T-SQL"));
            using (var context = ApplicationContext.UpdateMigration())
            {
                foreach (var item in dirs)
                {
                    context.Database.ExecuteSqlCommand(System.IO.File.ReadAllText(item));
                }
            }            
        }
    }
    
    
    public class YourModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (modelType.IsInterface)
            {
                return new InterfaceModelBinder();
            }
            return null;
        }
    }
    public class InterfaceModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ModelBindingContext context = new ModelBindingContext(bindingContext);
            var item = DependencyResolver.Current.GetService(bindingContext.ModelType);
    
            Func<object> modelAccessor = () => item;
            context.ModelMetadata = new ModelMetadata(new DataAnnotationsModelMetadataProvider(),
                bindingContext.ModelMetadata.ContainerType, modelAccessor, item.GetType(), bindingContext.ModelName);
    
            return base.BindModel(controllerContext, context);
        }
    }
