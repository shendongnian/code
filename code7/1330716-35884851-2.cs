    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var element = doc.Descendants("watchVideo").First();
            var names = element.AncestorsAndSelf()
                       .Reverse()
                       .Skip(1) // Skip the root
                       .Select(x => x.Name);
            var joined = string.Join(".", names);
            Console.WriteLine(joined);
        }
    }
