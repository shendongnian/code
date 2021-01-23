    public class MyModelBinder : IModelBinder {
      public object BindModel(ControllerContext controllerContext,     
                              ModelBindingContext bindingContext) {
        // create different concrete instance based on parameters
        ValueProviderResult code = bindingContext.ValueProvider.GetValue("Code");
        if (code.AttemptedValue != null) {
          // code is passed as a parameter, might be our class
          // create instance of StuffRegisterSearchParameterVM  and return it
        }
      
        // no Code parameter passed, check for others
      }
    }
