    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string url = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                int count = 0;
                DataSet ds = new DataSet();
                XmlReader xmlReader = XmlReader.Create(url);
                xmlReader.MoveToContent();
                try
                {
                    while (!xmlReader.EOF)
                    {
                        count++;
                        xmlReader.ReadToFollowing("job");
                        if (!xmlReader.EOF)
                        {
                            ds.ReadXml(xmlReader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Count : {0}", count);
                    Console.ReadLine();
                }
                
            }
        }
    }
