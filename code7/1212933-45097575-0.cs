    public class MyModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            try
            {
                bindingContext.Model = new TestClass();
                //following lines invoke default validation on model
                bindingContext.ValidationNode.ValidateAllProperties = true;
                bindingContext.ValidationNode.Validate(actionContext);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
