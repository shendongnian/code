     public class JSONPatch<T>
        {
            private Dictionary<string, object> propsJson = new Dictionary<string, object>();
    
            public JSONPatch()
            {
                Stream req = HttpContext.Current.Request.InputStream;
                req.Seek(0, System.IO.SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                propsJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
    
            public JSONPatch(object model)
            {
                propsJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(model.ToString());
            }
    
            public void Patch(T model)
            {
    
                PropertyInfo[] properties = model.GetType().GetProperties();
    
                foreach (PropertyInfo property in properties)
                {
                    try
                    {
                        if (!propsJson.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                            continue;
    
                        KeyValuePair<string, object> item = propsJson.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));
    
                        Type targetProp = model.GetType().GetProperty(property.Name).PropertyType;
    
                        Type targetNotNuable = Nullable.GetUnderlyingType(targetProp);
    
                        if (targetNotNuable != null)
                        {
                            targetProp = targetNotNuable;
                        }
    
    
                        if (item.Value.GetType() != typeof(Int64))
                        {
                            
                            object newA = Convert.ChangeType(item.Value, targetProp);
    
                            model.GetType().GetProperty(property.Name).SetValue(model, newA, null);
    
                        }
                        else
                        {
                            int value = Convert.ToInt32(item.Value);
    
                            if (targetProp.IsEnum)
                            {
                                object newA = Enum.Parse(targetProp, value.ToString());
                                model.GetType().GetProperty(property.Name).SetValue(model, newA, null);
                            }
                            else
                            {
                                object newA = Convert.ChangeType(value, targetProp);
                                model.GetType().GetProperty(property.Name).SetValue(model, newA, null);
                            }
    
                        }
    
                    }
                    catch
                    {
    
                    }
    
    
                }
            }
    
        }
