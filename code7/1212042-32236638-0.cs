    public class CustomModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            if(propertyDescriptor.PropertyType == typeof(decimal))
            {
                propertyDescriptor.SetValue(bindingContext.Model, double.Parse(propertyDescriptor.GetValue(bindingContext.Model).ToString()));
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
    }
