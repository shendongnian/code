    internal class Converter
    {
        public T CovertXML<T>(string XMLString) where T:class
        {
            if (XMLString.ToLower().Contains(typeof(Type1).GetType().Name.ToLower()))
            {
                return XMLString.Deseralize<Type1>() as T;
            }
            //..etc etc.
            return null;
        }
    }
    internal class Type1
    {
    }
    public static class StringExtensionMethods
    {
         public static T Deseralize<T>(this string Instance)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.StringReader sr = new System.IO.StringReader(Instance))
                return (T)ser.Deserialize(sr);
        }
    }
    
