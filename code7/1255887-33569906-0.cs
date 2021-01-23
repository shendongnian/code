    namespace WebApplication1.Models
    {
        public class MyModelBinder : DefaultModelBinder
        {
            protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
            {
                if (propertyDescriptor.ComponentType == typeof(MyModel))
                {
                    if (propertyDescriptor.Name == "Amount")
                    {
                        var obj = bindingContext.ValueProvider.GetValue("Amount");
                        return Convert.ToDouble(obj.AttemptedValue.Replace("£", ""));
                    }
                }
                return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
            }
        }
    }
