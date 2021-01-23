    [DataContract(Namespace="http://www.dd.org/OTA/")]
    [XmlSerializerFormat]
    public class NotifRQ 
    {
       [DataMember, XmlAttribute] 
       public string Status="Commit";
       
       [DataMember]
       public string  rev;
       [DataMember]
       public string  change;
    }
