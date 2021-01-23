    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string input = "<Text><![CDATA[Hello]]></Text><Text><![CDATA[World]]></Text>";
            string xml = "<root>" + input + "</root>";
            var doc = XDocument.Parse(xml);
            var nodes = doc.DescendantNodes().OfType<XCData>().ToList();
            foreach (var node in nodes)
            {
                node.ReplaceWith(new XText(node.Value));
            }
            var elements = doc.Root.Elements().ToList();
            elements.ForEach(Console.WriteLine);
        }
    }
