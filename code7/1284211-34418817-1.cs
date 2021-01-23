    WpData xmlObject = new WpData();
    
    //....
    //here you should fill it from excel based on your data
    
    //And then you can just serialize it to string 
    string xmlString;
    XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
    using(StringWriter textWriter = new StringWriter())
    {
        xmlSerializer.Serialize(textWriter, toSerialize);
        xmlString = textWriter.ToString();
    }
