    public class LocalDateModelBinder : IModelBinder
    {
        private readonly LocalDatePattern _localDatePattern = LocalDatePattern.IsoPattern;
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof (LocalDate))
                return false;
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
                return false;
            var rawValue = val.RawValue as string;
            var result = _localDatePattern.Parse(rawValue);
            if (result.Success)
                bindingContext.Model = result.Value;
            return result.Success;
        }
    }
