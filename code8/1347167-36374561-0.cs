    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Tmp();
            }
    
            public static void Tmp()
            {
    
                //ofx is an `XElement` containing many sub-elements of `XElement` type
                XDocument document = new XDocument(new XElement("myName", "myContent"));
    
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
    
                //destinationPath is a string containing a path, like this
                // e.g : "C:\\Users\\Myself\\Desktop"  
                string destionationPath = "D:\\Temp\\xml_test\\";
                using (var stream = File.Create(destionationPath + @"export.xml"))
                {
                    List<byte[]> header = new List<byte[]>();
    
                    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
    
                    List<string> headers = new List<string>();
                    headers.Add("foo");
    
                    // Just adding some headers here on the top of the file. 
                    // I'm pretty sure this is irrelevant for my problem
    
                    foreach (string item in headers)
                    {
                        header.Add(Encoding.ASCII.GetBytes(item));
                        header.Add(newline);
                    }
    
                    header.Add(newline);
    
                    byte[] bytes = header.SelectMany(a => a).ToArray();
    
                    stream.Write(bytes, 0, bytes.Length);
                    using (var writer = XmlWriter.Create(stream, settings))
                    {
                        document.Save(writer);
                    }
                }
            }
        }
    }
