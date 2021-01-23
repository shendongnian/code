    public static T FromXElement<T>(XElement element) where T : class, new() 
    {
        var typeOfT = typeof(T);
        T value = new T();
        foreach (var subElement in element.Elements())
        {
            var prop = typeOfT.GetProperty(subElement.Name.LocalName);
            if(prop != null)
            {
            	prop.SetValue(value, subElement.Value);
            }
         }
            return value;
     }
