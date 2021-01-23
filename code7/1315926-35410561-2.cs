    [XmlRoot(Namespace = "http://www.mywebsite.no/webservice/types")]
    public class SaveUser
    {
       ...
    }
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/mywebsite.Engine.Engine.Types")]
    public class User1
    {
       [XmlNamespaceDeclarations]
       public XmlSerializerNamespaces xmlns;
       ...
    }
