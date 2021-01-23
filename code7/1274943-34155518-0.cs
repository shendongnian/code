    public class Truncator {
        private const String Ellipsis = "…";
        private const String EllipsisHtmlEntity = "&hellip;";
        public static String Truncate(XElement xElement, Int32 length, Boolean useHtmlEntity = false) {
            if (ReferenceEquals(xElement, null))
                throw new ArgumentException(nameof(xElement));
            var textNode =
                (XText)
                xElement.DescendantNodes()
                        .FirstOrDefault(node => !ReferenceEquals(node, null) && node.NodeType == XmlNodeType.Text);
            if (!ReferenceEquals(textNode, null))
                textNode.Value = Truncate(textNode.Value, length);
            var truncatedResult = xElement.ToString(SaveOptions.DisableFormatting);
            return useHtmlEntity ? truncatedResult.Replace(Ellipsis, EllipsisHtmlEntity) : truncatedResult;
        }
        public static String Truncate(String str, Int32 length, Boolean useHtmlEntity = false) {
            if (String.IsNullOrWhiteSpace(str))
                return str;
            var truncated = str.Trim().Substring(0, length - 1).Trim();
            return String.IsNullOrWhiteSpace(str) || str.Length < length
                       ? str
                       : $"{truncated}{(useHtmlEntity ? EllipsisHtmlEntity : Ellipsis)}";
        }
    }
