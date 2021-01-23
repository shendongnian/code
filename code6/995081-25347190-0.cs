    public static string CheckAndGetElementValue(this XElement parent, string elementName, string defaultValue = null) 
    {
        var el = parent.Element(elementName);
        if(el != null)
        {
             return el.Value;
        }
        else
        {
             return defaultValue;
        }
    }
