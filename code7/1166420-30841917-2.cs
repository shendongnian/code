    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XElement myXML = XElement.Load("test.xml");
    
            IEnumerable<XElement> parentNodes = myXML.Descendants("ParentNode");
            var nodeAttributes = parentNodes
                .SelectMany(le => le.Descendants("Node"))
                .GroupBy(x => new { 
                    Id = x.Attribute("id").Value, 
                    Name = x.Attribute("name").Value 
                })
                .Select(g => new {
                    g.Key.Id,
                    g.Key.Name,
                    DistinctModeCount = g.Select(x => x.Attribute("mode").Value)
                                         .Distinct()
                                         .Count()
                });
            foreach (var item in nodeAttributes)
            {
                Console.WriteLine(item);
            }
        }
    }
