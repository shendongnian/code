    public T ADMSUpdate<T>(T entity, T originalEntity)
        {
            object propertyValue = null;
            PropertyInfo[] properties = originalEntity.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                propertyValue = null;
                if (null != property.GetSetMethod())
                {
                    PropertyInfo entityProperty = entity.GetType().GetProperty(property.Name);
                    propertyValue = entity.GetType().GetProperty(property.Name).GetValue(entity, null);
                    if (null != propertyValue)
                    {
                        property.SetValue(originalEntity, propertyValue, null);
                    }
                }
            }
            return entity;
        }
