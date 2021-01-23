    public static class FrameworkContentElementExtensions
    {
        public static string ToXaml(this FrameworkContentElement element) // For instance, a FlowDocument
        {
            if (element == null)
                return null;
            var sb = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(sb))
            {
                XamlWriter.Save(element, xmlWriter);
            }
            return sb.ToString();
        }
        public static string ToFormattedXamlString(this FrameworkContentElement element)
        {
            if (element == null)
                return null;
            var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " };
            var sb = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(sb, settings))
            {
                XamlWriter.Save(element, xmlWriter);
            }
            return sb.ToString();
        }
    }
