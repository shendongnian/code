    public class PersonModelBinder :DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            PersonType personType = GetValue<PersonType>(bindingContext, "PersonType");
            Type model = Person.SelectFor(personType);
            
            Person instance = (Person)base.CreateModel(controllerContext, bindingContext, model);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, model);
            return instance;
        }
        private T GetValue<T>(ModelBindingContext bindingContext, string key)
        {
            ValueProviderResult valueResult =bindingContext.ValueProvider.GetValue(key);
            bindingContext.ModelState.SetModelValue(key, valueResult);
            return (T)valueResult.ConvertTo(typeof(T));
        }  
    }
