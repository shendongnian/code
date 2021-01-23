    public class ImagePropertyModifier 
    {
        private PropertyInfo GetImageProperty(object obj)
        {
            var property = obj.GetType().GetProperty("Image");
            if (property == null)
                throw new Exception("Object has no Image property.");
            if (property.PropertyType != typeof(string))
                throw new Exception("Object's Image property is not a string.");
            return property;
        }
        private static string GetImage(object obj)
        {           
            return GetImageProperty(obj).GetValue(obj, null).ToString();
        }        
        private static string SetImage(object obj, string value)
        {
            GetImageProperty(obj).SetValue(obj, value);
        }        
    }
