    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var result = from x in doc.Root.Elements("Category")
                         where x.Element("Name").Value.Equals("Custom")
                         select x;
            Console.WriteLine(result.Count());
        }
    }
