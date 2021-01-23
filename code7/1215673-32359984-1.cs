    // method extracting property name & value
    private string GetProperty(JProperty property, string prefix = null)
    {
        string value = string.Empty;
        try
        {
            // if property value is another object, call method recursively
            var jsonObject = JObject.Parse(property.Value.ToString());
            foreach (JProperty innerProperty in jsonObject.Children<JProperty>())
                value += GetProperty(innerProperty, property.Name);  
        }
        catch (JsonReaderException)
        {
            // else just format return value
            value = string.Format(@"{0}:{1}{2}", 
                        prefix != null ? string.Format("{0} {1}", prefix, property.Name) : property.Name, 
                        property.Value, 
                        Environment.NewLine);
        }
        return value;
    }
