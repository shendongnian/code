    public static class EntityExtension {
       public static T Field<T>(this object entity, string field) {
    	   Type entityType = entity.GetType();
    	   PropertyInfo propertyInfo = entityType.GetProperty(field);
    	   if (propertyInfo == null) {
    		   throw new ArgumentException(string.Format("{0} doesn't exist on {1}", field, entityType.Name));
    	   }
    	   
    	   return (T)propertyInfo.GetValue(entity);
       }
    }
