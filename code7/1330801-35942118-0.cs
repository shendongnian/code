    public class AntiXSSModelBinder : IModelBinder
    {
        public Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelMetadata.IsComplexType)
            {
                // this type cannot be converted
                return ModelBindingResult.NoResultAsync;
            }
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                // no entry
                return ModelBindingResult.NoResultAsync;
            }
            var model = valueProviderResult.ConvertTo(bindingContext.ModelType);
            if (bindingContext.ModelType == typeof(string))
            {
                var modelAsString = model as string;
                
                if (model != null)
                {
                    return ModelBindingResult.SuccessAsync(bindingContext.ModelName, FilterPotentiallyXSSEntries(modelAsString));
                }
            }
            return ModelBindingResult.NoResultAsync;
        }
        private static string FilterPotentiallyXSSEntries(string value)
        {
            return value.Replace("<", "").Replace(">", "").Replace("script", "");
        }
    }
