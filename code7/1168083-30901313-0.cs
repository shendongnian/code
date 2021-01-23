    	[Serializable]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "yourNamespace")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "yourNamespace")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "yourNamespace")]
    public class CustomFault : ISerializable
    {
        public string Message { get; set; }
    }
