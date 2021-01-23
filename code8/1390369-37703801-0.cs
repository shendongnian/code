    public class MyModelBinder<T>
    {
        private ModelBindingContext modelBindingContext = new ModelBindingContext();
        /// <summary>
        /// Method to get model from QueryString
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>T model</returns>
        public static T GetModelFromQueryString(HttpRequest request)
        {
            modelBindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(T));
            modelBindingContext.ValueProvider = new NameValueCollectionValueProvider(request.QueryString, System.Globalization.CultureInfo.InvariantCulture);
            IModelBinder mb = new DefaultModelBinder();
            return (T)mb.BindModel(new ControllerContext(), modelBindingContext);
        }
        /// <summary>
        /// Method to get model from FormColletion
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns>T model</returns>
        public static T GetModelFromFormColletion(HttpRequest request)
        {
            modelBindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(T));
            modelBindingContext.ValueProvider = new NameValueCollectionValueProvider(request.Params, System.Globalization.CultureInfo.InvariantCulture);
            IModelBinder mb = new DefaultModelBinder();
            return (T)mb.BindModel(new ControllerContext(), modelBindingContext);
        }
    }
