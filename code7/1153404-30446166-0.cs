    public static Object CreateObject(string XMLString, Object YourClassObject)
    {
         System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(YourClassObject.GetType());
         //The StringReader will be the stream holder for the existing XML file 
         YourClassObject = oXmlSerializer.Deserialize(new System.IO.StringReader(XMLString));
         //initially deserialized, the data is represented by an object without a defined type 
         return YourClassObject;
    }
