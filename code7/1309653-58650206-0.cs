public class exampleClass
{
public exampleClass() { }
[System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
public string schemaLocation = "http://www.rewerse.net/I1/2006/R2ML http://oxygen.informatik.tu-cottbus.de/R2ML/0.4/R2ML.xsd";
}
 
XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
exampleClass example = new exampleClass();
XmlSerializer serializer = new XmlSerializer(typeof(exampleClass));
serializer.Serialize(Console.Out, example, namespaces);
