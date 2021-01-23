    static class HtmlTextProvider
    {
        private static readonly HashSet<string> InlineElementNames = new HashSet<string>
        {
            //from https://developer.mozilla.org/en-US/docs/Web/HTML/Inline_elemente
            "b", "big", "i", "small", "tt", "abbr", "acronym", 
            "cite", "code", "dfn", "em", "kbd", "strong", "samp", 
            "var", "a", "bdo", "br", "img", "map", "object", "q", 
            "script", "span", "sub", "sup", "button", "input", "label", 
            "select", "textarea"
        }; 
        
        private static readonly HashSet<string> ExcludedElementNames = new HashSet<string>
        {
            "script", "style"
        }; 
        private static readonly Regex WhitespaceNormalizer = new Regex(@"(\s+)", RegexOptions.Compiled);
        public static string GetFormattedInnerText(this HtmlDocument document)
        {
            var textBuilder = new StringBuilder();
            var root = document.DocumentNode;
            foreach (var node in root.Descendants())
            {
                if (node is HtmlTextNode && !ExcludedElementNames.Contains(node.ParentNode.Name))
                {
                    var text = HttpUtility.HtmlDecode(node.InnerText);
                    text = WhitespaceNormalizer.Replace(text, " ");
                    if(string.IsNullOrWhiteSpace(text))continue;
                    if (textBuilder.Length > 0 && !char.IsWhiteSpace(textBuilder[textBuilder.Length - 1]))
                    {
                        if (InlineElementNames.Contains(node.ParentNode.Name))
                        {
                            textBuilder.Append(' ');
                        }
                        else
                        {
                            textBuilder.AppendLine();
                        }
                    }
                    textBuilder.Append(text);
                }
                else if (node.Name == "br" && textBuilder.ToString(textBuilder.Length - Environment.NewLine.Length, Environment.NewLine.Length) != Environment.NewLine)
                {
                    textBuilder.AppendLine();
                }
            }
            return textBuilder.ToString();
        }
    }
