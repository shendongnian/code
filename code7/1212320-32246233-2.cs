            private static void ReflectObject(object objectToReflect)
            {
                foreach (var propertyInfo in objectToReflect.GetType().GetProperties())
                {
                    object propertyValue = propertyInfo.GetValue(objectToReflect, null);
                    if (IsEnumerable(propertyInfo))
                    {
                        foreach (object obj in (IEnumerable)propertyValue)
                        {
                            ReflectObject(obj);
                        }
                    }
                    else
                    {
                        Console.WriteLine(propertyValue);
                    }
                }
            }
    
            private static bool IsEnumerable(PropertyInfo propertyInfo)
            {
                return propertyInfo.PropertyType.IsGenericType &&
                         propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>);
            }
        }
