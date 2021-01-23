        public void UpdateSpecified(T entity)
        {
            var props = entity.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string))
                {
                    string propValue = prop.GetValue(entity, null) != null ? prop.GetValue(entity, null).ToString() : string.Empty;
                    if (!string.IsNullOrEmpty(propValue))
                    {
                        DataContext.Entry<T>(entity).Property(prop.Name).IsModified = true;
                    }
                    else
                    {
                        DataContext.Entry<T>(entity).Property(prop.Name).IsModified = false;
                    }
                }
            }
            
        }
