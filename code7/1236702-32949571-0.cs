                Cat c = new Cat()
                {
                    Hunger = 10,
                    Sleepiness = 10
                };
    
                dynamic dynamicCat = new ExpandoObject();
                IDictionary<string, object> dynamicCatExpando = dynamicCat;
    
                Type type = c.GetType();
                PropertyInfo[] properties = type.GetProperties();
    
                foreach (PropertyInfo property in properties)
                {
                    try
                    {
                        dynamicCatExpando.Add(property.Name, property.GetValue(c, null));
                    }
                    catch (Exception)
                    {
                        object defaultValue = type.IsValueType ? Activator.CreateInstance(type) : null;
                        dynamicCatExpando.Add(property.Name, defaultValue);
                    }
                }
    
                return Content(JsonConvert.SerializeObject(dynamicCatExpando), "application/Json");
