csharp
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class MyExportAttribute
    : ExportAttribute
    // Necessary to prevent sgen.exe from exploding since we are
    // a public type with a parameterless constructor.
    , System.Xml.Serialization.IXmlSerializable
{
    System.Xml.Schema.XmlSchema System.Xml.Serialization.IXmlSerializable.GetSchema() => throw new NotImplementedException("Not serializable");
    void System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader reader) => throw new NotImplementedException("Not serializable");
    void System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter writer) => throw new NotImplementedException("Not serializable");
}
