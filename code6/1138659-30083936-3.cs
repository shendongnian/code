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
        private static readonly Regex WhitespaceNormalizer = new Regex(@"(\s+)", RegexOptions.Compiled);
        
        private static readonly HashSet<string> ExcludedElementNames = new HashSet<string>
        {
            "script", "style"
        }; 
        public static string GetFormattedInnerText(this HtmlDocument document)
        {
            var textBuilder = new StringBuilder();
            var root = document.DocumentNode;
            foreach (var node in root.Descendants())
            {
                if (node is HtmlTextNode && !ExcludedElementNames.Contains(node.ParentNode.Name))
                {
                    var text = HttpUtility.HtmlDecode(node.InnerText);
                    text = WhitespaceNormalizer.Replace(text, " ").Trim();
                    if(string.IsNullOrWhiteSpace(text)) continue;
                    var whitespace = InlineElementNames.Contains(node.ParentNode.Name) ? " " : Environment.NewLine;
                    //only 
                    if (EndsWith(textBuilder, " ") && whitespace == Environment.NewLine)
                    {
                        textBuilder.Remove(textBuilder.Length - 1, 1);
                        textBuilder.AppendLine();
                    }
                    textBuilder.Append(text);
                    textBuilder.Append(whitespace);
                    if (!char.IsWhiteSpace(textBuilder[textBuilder.Length - 1]))
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
                }
                else if (node.Name == "br" && EndsWith(textBuilder, Environment.NewLine))
                {
                    textBuilder.AppendLine();
                }
            }
            return textBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
        private static bool EndsWith(StringBuilder builder, string value)
        {
            return builder.Length > value.Length && builder.ToString(builder.Length - value.Length, value.Length) == value;
        }
    }
