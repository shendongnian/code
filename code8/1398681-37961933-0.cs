    public static bool PublicInstancePropertiesEqual<T>(T value, T tobecompared) where T : class 
      {
         if (value!= null && tobecompared!= null)
         {
            Type type = typeof(T);
            foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                  object selfValue = type.GetProperty(pi.Name).GetValue(self, null);//Get Current value
                  object toValue = getCompareToValue();
    
                  if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                  {
                     return false;
                  }
            }
            return true;
         }
         return value == tobecompared;
      }
