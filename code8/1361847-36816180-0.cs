    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var reader = XmlReader.Create(new FileStream(Console.ReadLine(), FileMode.Open, FileAccess.ReadWrite, FileShare.Read)))
                {
                    while (!reader.EOF)
                    {
                        if (reader.Name != "name")
                        {
                            reader.ReadToFollowing("name");
                        }
                        if(!reader.EOF)
                        {
                            XElement name = (XElement)XElement.ReadFrom(reader);
                        }
                    }
                }
            }
        }
    }
