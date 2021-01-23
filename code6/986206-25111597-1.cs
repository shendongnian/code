    public class InterfaceModelBinderProvider : IModelBinderProvider
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
            var item = DependencyResolver.Current.GetService(bindingContext.ModelType);
    
            bindingContext.ModelMetadata = new ModelMetadata(new DataAnnotationsModelMetadataProvider(),
                bindingContext.ModelMetadata.ContainerType, () => item, item.GetType(), bindingContext.ModelName);
    
            return base.BindModel(controllerContext, bindingContext);
        }
    }
