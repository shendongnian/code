    public static sampleField  ObjectToXML(string XmlOfAnObject, Type ObjectType) {
      StringReader StrReader = new StringReader(XmlOfAnObject);
      XmlSerializer serializer = new XmlSerializer(ObjectType);
      XmlTextReader XmlReader = new XmlTextReader(StrReader);
      try {
        sampleField AnObject = serializer.Deserialize(XmlReader);
        return AnObject;
      } catch (Exception exp) {
        //Handle Exception Code
      } finally {
        XmlReader.Close();
        StrReader.Close();
      }
    }
