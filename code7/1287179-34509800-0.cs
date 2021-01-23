    public class ImagePropertyModifier 
    {
        private PropertyInfo GetProperty(object obj)
        {
            var property = obj.GetType().GetProperty("Image");
            if (property.PropertyType != typeof(string))
                throw new Exception("Object is not a string.");
            return property;
        }
        private static string GetImage(object obj)
        {
            var property = GetProperty(obj);
            
            if (property == null) 
                throw new Exception("Object has no Image property.");
            return property.GetValue(obj, null).ToString();
        }        
        private static string SetImage(object obj, string value)
        {
            var property = GetProperty(obj);
            
            if (property == null) 
                throw new Exception("Object has no Image property.");
            property.SetValue(obj, value);
        }        
    }
