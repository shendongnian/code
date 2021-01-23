    public static class Extensions
    {
        public static IEnumerable<XElement> LocalElements<T>(this T source, string name)
                where T : XContainer
        {
            return source.Elements().Where(e => e.Name.LocalName == name);
        }
        
        public static IEnumerable<XElement> LocalDescendants<T>(this T source, string name)
                where T : XContainer
        {
            return source.Descendants().Where(e => e.Name.LocalName == name);
        }
        
        public static XElement LocalElement<T>(this T source, string name)
                where T : XContainer
        {
            return LocalElements(source, name).FirstOrDefault();
        }
    }
