     public T Map<T>(object input) where T : new()
        {
            T obj = new T();
            MovieMapAttribute[] classAttributes = (MovieMapAttribute[])obj.GetType().GetCustomAttributes(typeof(MovieMapAttribute), false);
            if (classAttributes != null && classAttributes[0].ClassName.Equals(input.GetType().Name))
            {
                Dictionary<string, MovieMapPropertyAttribute> propAtts = new Dictionary<string, MovieMapPropertyAttribute>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    MovieMapPropertyAttribute[] mma = (MovieMapPropertyAttribute[])prop.GetCustomAttributes(typeof(MovieMapPropertyAttribute), false);
                    // Attribute found
                    if (mma.Length > 0)
                    {
                        // Get attribute
                        MovieMapPropertyAttribute mmp = mma[0];
                        if (input.GetType().GetProperty(mmp.PropertyName) != null)
                        {
                            // Get value
                            var value = input.GetType().GetProperty(mmp.PropertyName).GetValue(input, null);
                            // Is property a dateTime
                            if (typeof(DateTime).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                obj.GetType().GetProperty(prop.Name).SetValue(obj, Convert.ToDateTime(value), null);
                            }
                            else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string) && prop.PropertyType != typeof(string[]))
                            {
                                Type type = prop.PropertyType.GetGenericArguments()[0];
                                var list = (IEnumerable)value;
                                dynamic values = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                                foreach (object ob in list)
                                {
                                    object tempObj = Activator.CreateInstance(type);
                                    tempObj = Map(ob, tempObj);
                                    values.Add((dynamic)tempObj);
                                }
                                obj.GetType().GetProperty(prop.Name).SetValue(obj, values, null);
                            }
                            else if (typeof(Boolean).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                obj.GetType().GetProperty(prop.Name).SetValue(obj, Convert.ToBoolean(value), null);
                            }
                            else if (typeof(int).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                obj.GetType().GetProperty(prop.Name).SetValue(obj, Convert.ToInt32(value), null);
                            }
                            else if (typeof(float).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                obj.GetType().GetProperty(prop.Name).SetValue(obj, float.Parse(value.ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat), null);
                            }
                            else
                            {
                                // Set value to object
                                obj.GetType().GetProperty(prop.Name).SetValue(obj, value, null);
                            }
                        }
                    }        
                }
            }
            else
                throw new Exception("Wrong object");
            return obj;
        }       
        private object Map(object input, object output)
        {
            MovieMapAttribute[] classAttributes = (MovieMapAttribute[])output.GetType().GetCustomAttributes(typeof(MovieMapAttribute), false);
            if (classAttributes != null && classAttributes[0].ClassName.Equals(input.GetType().Name))
            {
                foreach (PropertyInfo prop in output.GetType().GetProperties())
                {
                    MovieMapPropertyAttribute[] mma = (MovieMapPropertyAttribute[])prop.GetCustomAttributes(typeof(MovieMapPropertyAttribute), false);
                    // Attribute found
                    if (mma.Length > 0)
                    {
                        // Get attribute
                        MovieMapPropertyAttribute mmp = mma[0];
                        if (input.GetType().GetProperty(mmp.PropertyName) != null)
                        {
                            var value = input.GetType().GetProperty(mmp.PropertyName).GetValue(input, null);
                            // Is property a dateTime
                            if (typeof(DateTime).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                output.GetType().GetProperty(prop.Name).SetValue(output, Convert.ToDateTime(value), null);
                            }
                            else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string) && prop.PropertyType != typeof(string[]))
                            {
                                Type type = prop.PropertyType.GetGenericArguments()[0];
                                var list = (IEnumerable)value;
                                dynamic values = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                                foreach (object ob in list)
                                {
                                    object tempObj = Activator.CreateInstance(type);
                                    tempObj = Map(ob, tempObj);
                                    values.Add((dynamic)tempObj);
                                }
                                output.GetType().GetProperty(prop.Name).SetValue(output, values, null);
                            }
                            else if (typeof(Boolean).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                output.GetType().GetProperty(prop.Name).SetValue(output, Convert.ToBoolean(value), null);
                            }
                            else if (typeof(int).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                output.GetType().GetProperty(prop.Name).SetValue(output, Convert.ToInt32(value), null);
                            }
                            else if (typeof(float).IsAssignableFrom(prop.PropertyType))
                            {
                                // Set value to object
                                output.GetType().GetProperty(prop.Name).SetValue(output, float.Parse(value.ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat), null);
                            }
                            else
                            {
                                // Set value to object
                                output.GetType().GetProperty(prop.Name).SetValue(output, value, null);
                            }
                        }                        
                    }
                }
            }
            else
                throw new Exception("Wrong object");
            return output;
        }       
