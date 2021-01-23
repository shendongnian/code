        public class OrderModelBinder : DefaultModelBinder 
        {
           protected override bool OnPropertyValidating(ControllerContext controllerContext, ModelBindingContext bindingContext,
        PropertyDescriptor propertyDescriptor, object value)
           {
               if ((propertyDescriptor.PropertyType == typeof(DateTime) && value == null) ||
                  (propertyDescriptor.PropertyType == typeof(int) && value == null) ||
                  (propertyDescriptor.PropertyType == typeof(decimal) && value == null) ||
                  (propertyDescriptor.PropertyType == typeof(bool) && value == null))
               {
                   var modelName = string.IsNullOrEmpty(bindingContext.ModelName) ? "" : bindingContext.ModelName + ".";
                   var name = modelName + propertyDescriptor.Name;
                   bindingContext.ModelState.AddModelError(name, General.RequiredField);
                }
            return base.OnPropertyValidating(controllerContext, bindingContext, propertyDescriptor, value);
            }
        }
