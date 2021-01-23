        private Object SetPropertyValue(Object entity, string property, string value)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty(property);
            if (propertyInfo != null)
            {
                Type t = propertyInfo.PropertyType;
                object d;
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (String.IsNullOrEmpty(value))
                        d = null;
                    else
                        d = Convert.ChangeType(value, t.GetGenericArguments()[0]);
                }
                else if (t == typeof(Guid))
                {
                    d = new Guid(value);
                }
                else
                {
                    d = Convert.ChangeType(value, t);
                }
                propertyInfo.SetValue(entity, d, null);
            }
            return entity;
        }
