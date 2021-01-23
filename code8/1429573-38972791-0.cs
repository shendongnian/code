    namespace XmlReaderOnByteArray
    {
        using System;
        using System.Xml;
    
        class Program
        {
            public static void Main(string[] args)
            {
                // Some XML
                string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <note>
                    <to>Tove</to>
                    <from>Jani</from>
                    <heading>Reminder</heading>
                    <body>Don't forget me this weekend!</body>
                    </note>";
                // Get buffer from string
                ArraySegment<byte> arraySegment = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(xml));
                // Use XmlDictionaryReader.CreateTextReader to create reader on byte array
                using (var reader = XmlDictionaryReader.CreateTextReader(arraySegment.Array, new XmlDictionaryReaderQuotas())) {
                    while (reader.Read()) {
                        Console.WriteLine("{0}[{1}] => {2}", reader.Name, reader.NodeType, reader.Value);
                    }
                }
            }
        }
    }
