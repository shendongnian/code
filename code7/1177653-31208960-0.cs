    public class ApolloModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            var request = controllerContext.HttpContext.Request;
            decimal i;
            var value = request.Form[propertyDescriptor.Name];
            if (propertyDescriptor.PropertyType == typeof(decimal) && decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out i))
            {
                propertyDescriptor.SetValue(bindingContext.Model, i);
                return;
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
