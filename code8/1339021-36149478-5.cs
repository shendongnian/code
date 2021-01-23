    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var hierarchy = doc.Root.Elements("file")
                       .Select(x => x.DescendantsAndSelf("file")
                                     .Select(f => (int) f.Attribute("name"))
                                     .ToList());
            
            foreach (var item in hierarchy)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }
    }
