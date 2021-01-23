    public class IFieldModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(
        ControllerContext controllerContext,
        ModelBindingContext bindingContext,
        Type modelType)
        {
     
            // Get the submitted type - should be IField
            var type = bindingContext.ModelType;
     
            // Get the posted 'class name' key - bindingContext.ModelName will return something like Section.FieldSections[0] in our particular context, and 'FieldClassName' is the property we're looking for
            var fieldClassName = bindingContext.ModelName + ".FieldClassName";
     
            // Do the same for the assembly name
            var fieldAssemblyName = bindingContext.ModelName + ".FieldAssemblyName";
     
            // Check that the values aren't empty/null, and use the bindingContext.ValueProvider.GetValue method to get the actual posted values
     
            if (!String.IsNullOrEmpty(fieldClassName) && !String.IsNullOrEmpty(fieldAssemblyName))
            {
                // The value provider returns a string[], so get the first ([0]) item
                var className = ((string[])bindingContext.ValueProvider.GetValue(fieldClassName).RawValue)[0];
                // Do the same for the assembly name
                var assemblyName =
                ((string[])bindingContext.ValueProvider.GetValue(fieldAssemblyName).RawValue)[0];
     
                // Once you have the assembly and the class name, get the type - I am overwriting the IField object that came in, but I do not think you have to do that
                modelType = Type.GetType(className + ", " + assemblyName);
     
                // Finally, create an instance of this type
                var instance = Activator.CreateInstance(modelType);
     
                // Update the binding context's meta data
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, modelType);
     
                // Return the instance - which will now be a SummaryField or CommentField - rather than an IField
                return instance;
            }
            return null;
        }
    }
