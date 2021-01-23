        using System.Xml;
        using System.Xml.Serialization;
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Text;
        public class SerializationUtils
        {
            public static T Deserialize<T>(string data)
            {           
                XmlSerializer objSerializer = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(data))
                {
                    return (T)objSerializer.Deserialize(reader);
                }
            }
    
            public static string Serialize<T>(T obj)
            {
                XmlSerializer objSerializer = new XmlSerializer(typeof(T));
                XmlSerializerNamespaces emptyNamespaces = new XmlSerializerNamespaces(new [] { XmlQualifiedName.Empty });
                
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.ConformanceLevel = ConformanceLevel.Auto;
    #if DEBUG
                settings.Indent = true;
    #else
                settings.Indent = false;
    #endif
    
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    objSerializer.Serialize(writer, obj, emptyNamespaces);
                    return stream.ToString();
                }
            }
        }
