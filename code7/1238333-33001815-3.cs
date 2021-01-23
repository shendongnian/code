    public static class FrameworkContentElementExtensions
    {
        public static XElement ToXamlXElement(this FrameworkContentElement element) // For instance, a FlowDocument
        {
            if (element == null)
                return null;
            var doc = new XDocument();
            using (var xmlWriter = doc.CreateWriter())
            {
                XamlWriter.Save(element, xmlWriter);
            }
            var xElement = doc.Root;
            if (xElement != null)
                xElement.Remove();
            return xElement;
        }
    }
