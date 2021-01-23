    public class ViewModelBaseBinderProvider
        : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            // this or whatever condition you want to apply to determine
            // if your model binder needs to be used.
            if (typeof(ViewModelBase).IsAssignableFrom(modelType))
                return new JsonPropertyBinder();
    
            // this means, the view model did not match our criteria   
            // let it flow through the usual model binders.       
            return null;
        }
    }
