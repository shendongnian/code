    public class DiModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType)
            {
                var propertyBinders = context.Metadata.Properties.ToDictionary(property => property, context.CreateBinder);
                return new DiModelBinder(propertyBinders);
            }
            return null;
        }
    }
