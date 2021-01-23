    public static class DirtyProperties
    {
        public static T ToUpdatedObject<T>(T entityObject)
        {
            return UpdateObject(entityObject,GetDirtyProperties());
        }
        private static Dictionary<string,object>GetDirtyProperties()
        {
            //Inspects the JSON payload for properties explicitly set.
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd());
        }
        private static T UpdateObject<T>(T entityObject, Dictionary<string, object> properties)
        {
            //Loop through each changed properties and update the entity object with new values
            foreach (var prop in properties)
            {
                var updateProperty = entityObject.GetType().GetProperty(prop.Key);// Try and get property
                if (updateProperty != null)
                {
                    SetValue(updateProperty, entityObject, prop.Value);
                }
            }
            return entityObject;
        }
        private static void SetValue(PropertyInfo property, object entity, object newValue)
        {
            //This method is used to convert binding model properties to entity properties and set the new value
            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            object safeVal = (newValue == null) ? null : Convert.ChangeType(newValue, t);
            property.SetValue(entity, safeVal);
        }
    }
