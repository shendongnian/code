    using System.IO;
    using System.Xml.Serialization;
    public class Serializer
    {
    /// <summary>
    /// Serialize an object to an XML string
    /// </summary>    
    public string Serialize(object obj)
    {
        using (var sw = new StringWriter())
        {
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(sw, obj);
            return sw.ToString();
        }
    }
    /// <summary>
    /// Deserialize an XML string to an object
    /// </summary>   
    public T Deserialize<T>(string xml)
    {
        using (var sw = new StringReader(xml))
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(sw);
        }
    }
    }
