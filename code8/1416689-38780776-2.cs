    public class RangeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var input = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();
                var inputType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
                // invoke generic method with proper type
                var method = typeof(RangeFilterParse).GetMethod(nameof(RangeFilterParse.Parse), BindingFlags.Static);
                var generic = method.MakeGenericMethod(inputType);
                var result = generic.Invoke(this, new object[] { input });
                bindingContext.Result = ModelBindingResult.Success(result);
                return Task.CompletedTask;
            }
            catch(Exception) // or catch a more specific error related to parsing
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }
        }
    }
