        public static NameValueCollection ObjectToCollection(object objects)
        {
            NameValueCollection parameter = new NameValueCollection();
            Type type = objects.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance |
                                                            BindingFlags.DeclaredOnly |
                                                            BindingFlags.Public);
            foreach (var property in CollectPropertiesIncludingNestedTypes(objects, properties))
            {
                parameter.Add(property.Item1, property.Item2);
            }
            return parameter;
        }
        private static IEnumerable<Tuple<string, string>> CollectPropertiesIncludingNestedTypes(object source, PropertyInfo[] properties)
        {
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(source, null) == null)
                {
                    yield return new Tuple<string, string>(property.Name.ToString(), "");
                }
                else
                {
                    var propValue = property.GetValue(source, null);
                    if (propValue.ToString() != "removeProp")
                    {
                        if (!(property.PropertyType.IsPrimitive || property.PropertyType == typeof(string)
                        || property.PropertyType == typeof(Guid) || property.PropertyType == typeof(DateTime)))
                        {
                            foreach (var val in CollectPropertiesIncludingNestedTypes(propValue, property.PropertyType.GetProperties(BindingFlags.Instance |
                                                            BindingFlags.DeclaredOnly |
                                                            BindingFlags.Public)))
                                yield return val;
                        }
                        else
                        {
                            yield return new Tuple<string, string>(property.Name.ToString(), propValue.ToString());
                        }
                    }
                }
            }
        }
