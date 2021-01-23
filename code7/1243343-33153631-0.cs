    public class Group
    {
       [XmlAttribute (Namespace = "http://www.cpandl.com")]
       public string GroupName;
       [XmlAttribute(DataType = "base64Binary")]
       public Byte [] GroupNumber;
       [XmlAttribute(DataType = "date", AttributeName = "CreationDate")]
       public DateTime Today;
   
       [XmlAttribute("space", Namespace = "http://www.w3.org/XML/1998/namespace")]
       public string Space ="preserve";
    }
