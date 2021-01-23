    using System.IO;
    using System.Xml;
    
    namespace StackoverflowXmlFilesConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                WriteXml("test.xml");
                WriteXml("test.xml");
            }
    
            static void WriteXml(string path)
            {
                using (var stream  = File.Open(path, FileMode.Create))
                {
                    using (var writer = XmlWriter.Create(stream))
                    {
                        writer.WriteStartDocument();
                        // replace this code with your XML writing code.
                        writer.WriteStartElement("Test");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }
            }
        }
    }
