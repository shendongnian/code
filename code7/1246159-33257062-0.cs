    public class DogModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Dog))
            {
                return false;
            }
            var model = (Dog)bindingContext.Model ?? new Dog();
            var hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
            var searchPrefix = (hasPrefix) ? bindingContext.ModelName + "." : "";
            model.NickName = GetValue(bindingContext, searchPrefix, "nick_name");
            int colorId = 0;
            if (int.TryParse(GetValue(bindingContext, searchPrefix, "colour"), out colorId))
            {
                model.Color = colorId; // <1>
            }
            bindingContext.Model = model;
            return true;
        }
        private string GetValue(ModelBindingContext context, string prefix, string key)
        {
            var result = context.ValueProvider.GetValue(prefix + key); // <4>
            return result == null ? null : result.AttemptedValue;
        }
    }
  
