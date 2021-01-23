    [Serializable]
    public class Data
    {
      public string TypeName {get;set;} // typeof(string), typeof(int), etc.
      public string Xml {get;set;} // serialized object via XmlSerializer
    }
