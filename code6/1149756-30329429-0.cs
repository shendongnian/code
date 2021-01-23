    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;
    
    
    class Program
    {
        static void Main()
        {
            var bytes = new Program().Serialize();
            File.WriteAllBytes("my.xml", bytes);
        }
        public byte[] Serialize()
        {
            using (var stream = new MemoryStream())
            {
                WriteXmlToStream(stream);
    
                return stream.ToArray();
            }
        }
    
        private void WriteXmlToStream(MemoryStream stream)
        {
            var document =
                new XDocument(
                    new XElement("Coleta",
                        new XElement("Operador", "foo"),
                        new XElement("Sujeito", "bar"),
                        new XElement("Início", DateTime.Now),
                        new XElement("Descrição", "Descrição")
                        // and so on
                        )
                    );
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
            {
                document.Save(writer);
            }
        }
    }
