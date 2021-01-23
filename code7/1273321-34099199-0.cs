    public static class XObjectExtensions
    {
        public static IEnumerable<string> DumpXmlAttributeNames(this XObject obj)
        {
            if (obj is XAttribute)
                return new[] { ((XAttribute)obj).Name.ToString() };
            else if (obj is XElement)
            {
                return ((XElement)obj).Attributes().Select(a => a.Name.ToString());
            }
            return Enumerable.Empty<string>();
        }
        public static IEnumerable<string> DumpXmlElementNames(this XElement root)
        {
            if (root == null)
                return Enumerable.Empty<string>();
            return root.DescendantsAndSelf().Select(el => string.Format("{0} \"{1}\"; Attribute names: {2}",
                new string(' ', el.AncestorsAndSelf().Count()), el.Name.ToString(), String.Join(", ", el.DumpXmlAttributeNames().Select(s => "\"" + s + "\""))));
        }
        public static IEnumerable<string> DumpXmlElementNames(this XDocument root)
        {
            if (root == null)
                return Enumerable.Empty<string>();
            return root.Root.DumpXmlElementNames();
        }
    }
