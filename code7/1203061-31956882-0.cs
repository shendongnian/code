                var xdoc = XDocument.Load(args[3]);    
                var parsedXml = x.XPathSelectElements(args[2]);
    
                foreach (XElement e in parsedXml)
                {
                    Console.WriteLine(((XElement)e.FirstNode).Value);
                    Console.WriteLine(((XElement)e.LastNode).Value);
                }
