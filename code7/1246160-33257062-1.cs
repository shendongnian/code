    public class DogModelBinderProvider : ModelBinderProvider
    {
        private CollectionModelBinderProvider originalProvider = null;
        public DogModelBinderProvider(CollectionModelBinderProvider originalProvider)
        {
            this.originalProvider = originalProvider;
        }
        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            // get the default implementation of provider for handling collections
            IModelBinder originalBinder = originalProvider.GetBinder(configuration, modelType);
            if (originalBinder != null)
            {
                return new DogModelBinder();
            }
            return null;
        }
    }
