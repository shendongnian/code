    public static class XmlPremOutHelper
    {
        public static void ReorderPremiumElements(TextReader from, TextWriter to)
        {
            var doc = XDocument.Load(from);
            foreach (var node in doc.Descendants("PREMout"))
            {
                var g = node.Elements().GroupBy(e => e.Name);
                foreach (var nodes in g)
                {
                    nodes.Remove();
                    node.Add(nodes);
                }
            }
            doc.Save(to);
        }
    }
