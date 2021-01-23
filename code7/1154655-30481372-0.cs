    public class RejectUnrecognizedPropertiesAttribute : Attribute, IControllerConfiguration 
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Formatters.Remove(controllerSettings.Formatters.JsonFormatter);
    
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = 
                {
                    MissingMemberHandling = MissingMemberHandling.Error
                }
            };
    
            controllerSettings.Formatters.Add(formatter);
        }
    }
