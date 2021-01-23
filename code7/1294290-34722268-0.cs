    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    {      
        var model = Activator.CreateInstance(modelType);
        var properties = modelType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        foreach(var property in properties)
        {
           var attribute = property.Attributes.OfType<InterfaceBinderAttribute>().FirstOrDefault();
           if(attribute != null)
           {
               var requiredType = (attribute as InterfaceBinderAttribute).ActualType;
               property.SetValue(model, Activator.CreateInstance(requiredType ), null);
           }
        }
        return model;
    }
