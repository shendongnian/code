    public static class FlowDocumentHelper
    {
        public static string ToFormattedXamlString(this FlowDocument doc)
        {
            if (doc == null)
                return null;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            var sb = new StringBuilder();
            var xmlWriter = XmlWriter.Create(sb, settings);
            XamlWriter.Save(doc, xmlWriter);
            return sb.ToString();
        }
        public static string DebugFlowDocumentXaml(this FlowDocument doc)
        {
            var str = doc.ToFormattedXamlString();
            Debug.WriteLine(str);
            return str;
        }
    }
