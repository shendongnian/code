    // Raw prototype code
    public class JsonFromDataVariable : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Product))
            {
                return false;
            }
            var value = bindingContext.ValueProvider.GetValue("data");
            if (value != null && value.RawValue != null)
            {
                var serializer = new JsonSerializer();
                var product = JsonSerializer
                                    .Create()
                                    .Deserialize<Product>(new JsonTextReader(new StringReader(value.RawValue.ToString())));
                bindingContext.Model = product;
                return true;
            }
            return false;
        }
    }
    public class JsonFromDataVariableProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
        {
            return new JsonFromDataVariable();
        }
    }
