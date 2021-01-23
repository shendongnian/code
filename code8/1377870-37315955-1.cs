    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //If the xml file is in the solution - set Build Action of the file to "Embedded Resource" 
                //and Copy to Output Directory to "Copy always"
                var doc = XDocument.Load("input.xml");
    
                doc.Element("response").Elements().ToList().ForEach(e =>
                    {
                        string number = e.Element("Detail").Element("number").Value;
                        string date = e.Element("FromDate").Element("date").Value;
    
                        Console.WriteLine("Number - {0}.Date - {1}\n", number, date);
                    });
    
                Console.ReadKey();
            }
        }
    }
