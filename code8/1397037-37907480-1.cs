    public class MyDecryptingBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.Name == "Id")
            {
                var idParam = bindingContext.ValueProvider.GetValue("Id");
                if (idParam != null)
                {
                    string rawValue = idParam.RawValue as string;
                    int value;
                    if (this.DecryptId(rawValue, out value))
                    {
                        propertyDescriptor.SetValue(bindingContext.Model, value);
                        return;
                    }
                }
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
        private bool DecryptId(string raw, out int id)
        {
            // TODO: you know what to do here: decrypt the raw value and 
            // set it to the id parameter, or just return false if decryption fails
        }
    }
