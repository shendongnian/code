     public static object CompareEquals(this T objectFromCompare, T objectToCompare)//Generic method
     
    {
    
     if (objectFromCompare == null && objectToCompare == null)
     return true;
     else if (objectFromCompare == null && objectToCompare != null)
     return false;
     else if (objectFromCompare != null && objectToCompare == null)
     return false;
    
     //Gets all the properties of the class
     PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
     foreach (PropertyInfo prop in props)
     {
     object dataFromCompare = objectFromCompare.GetType().GetProperty(prop.Name).GetValue(objectFromCompare, null);
     object dataToCompare = objectToCompare.GetType().GetProperty(prop.Name).GetValue(objectToCompare, null);
     Type type = objectFromCompare.GetType().GetProperty(prop.Name).GetValue(objectToCompare, null).GetType();
     if (prop.PropertyType.IsClass && !prop.PropertyType.FullName.Contains("System.String"))
     {
     dynamic convertedFromValue = Convert.ChangeType(dataFromCompare, type);
     dynamic convertedToValue = Convert.ChangeType(dataToCompare, type);
    
     object result = CompareTwoObjects.CompareEquals(convertedFromValue, convertedToValue);
    
     bool compareResult = (bool)result;
     if (!compareResult)
     return false;
     }
    
    
     else if (!dataFromCompare.Equals(dataToCompare))
     return false;
     }
    
     return true;
     
    
    }
