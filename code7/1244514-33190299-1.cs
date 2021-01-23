    public class BoolModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                             PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.PropertyType == typeof(bool))
            {
                Stream req = controllerContext.RequestContext.HttpContext.Request.InputStream;
                req.Seek(0, SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
    
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    
                string value = data[propertyDescriptor.Name];
                bool @bool = Convert.ToBoolean(int.Parse(value));
                propertyDescriptor.SetValue(bindingContext.Model, @bool);
                return;
            }
            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
    }
