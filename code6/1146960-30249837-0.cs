    public static class XExtensions
    {
        public static string GetAbsoluteXPathByAttribute(this XElement element, string attributeName)
        {
            Func<XElement, string> relativeXPath = e => RelativeXPathByAttribute(e, attributeName);
            return GetXPath(element, relativeXPath);
        }
        static string RelativeXPathByAttribute(XElement element, string attributeName)
        {
            var attr = element.Attribute(attributeName);
            if (attr != null)
            {
                var name = string.Format("*[@{0}={1}]", attributeName, XPathLiteral(attr.Value));
                var index = IndexPosition(element, e => { var a = e.Attribute(attributeName); return a != null && a.Value == attr.Value; });
                if (index != -1)
                    name = string.Format(NumberFormatInfo.InvariantInfo, "/{0}[{1}]", name, index);
                return name;
            }
            else if (!string.IsNullOrEmpty(element.Name.Namespace.ToString()))
            {
                string name = string.Format("*[local-name()={0}]", XPathLiteral(element.Name.LocalName));
                var index = IndexPosition(element, e => e.Name.LocalName == element.Name.LocalName);
                if (index != -1)
                    name = string.Format(NumberFormatInfo.InvariantInfo, "/{0}[{1}]", name, index);
                return name;
            }
            else
            {
                string name = element.Name.LocalName;
                var index = IndexPosition(element, e => e.Name == element.Name);
                if (index != -1)
                    name = string.Format(NumberFormatInfo.InvariantInfo, "/{0}[{1}]", name, index);
                return name;
            }
        }
        public static int IndexPosition(this XElement element)
        {
            return IndexPosition(element, e => e.Name == element.Name);
        }
        public static int IndexPosition(XElement element, Func<XElement, bool> isRelevant)
        {
            if (element == null || isRelevant == null)
                throw new ArgumentNullException();
            if (element.Parent == null)
                return -1;
            int i = 1; // Indexes for nodes start at 1, not 0
            foreach (var sibling in element.Parent.Elements().Where(isRelevant))
            {
                if (sibling == element)
                {
                    return i;
                }
                i++;
            }
            throw new InvalidOperationException("element has been removed from its parent.");
        }
        static string GetXPath(XElement element, Func<XElement, string> relativeXPath)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if (relativeXPath == null)
                throw new ArgumentNullException("relativeXPath");
            var ancestors = from e in element.Ancestors()
                            select relativeXPath(e);
            return string.Concat(ancestors.Reverse().ToArray()) +
                   relativeXPath(element);
        }
        /// <summary>
        /// Produce an XPath literal equal to the value if possible; if not, produce
        /// an XPath expression that will match the value.
        /// From http://stackoverflow.com/questions/1341847/special-character-in-xpath-query
        /// 
        /// Note that this function will produce very long XPath expressions if a value
        /// contains a long run of double quotes.
        /// </summary>
        /// <param name="value">The value to match.</param>
        /// <returns>If the value contains only single or double quotes, an XPath
        /// literal equal to the value.  If it contains both, an XPath expression,
        /// using concat(), that evaluates to the value.</returns>
        static string XPathLiteral(string value)
        {
            // if the value contains only single or double quotes, construct
            // an XPath literal
            if (!value.Contains("\""))
            {
                return "\"" + value + "\"";
            }
            if (!value.Contains("'"))
            {
                return "'" + value + "'";
            }
            // if the value contains both single and double quotes, construct an
            // expression that concatenates all non-double-quote substrings with
            // the quotes, e.g.:
            //
            //    concat("foo", '"', "bar")
            StringBuilder sb = new StringBuilder();
            sb.Append("concat(");
            string[] substrings = value.Split('\"');
            for (int i = 0; i < substrings.Length; i++)
            {
                bool needComma = (i > 0);
                if (substrings[i] != "")
                {
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append("\"");
                    sb.Append(substrings[i]);
                    sb.Append("\"");
                    needComma = true;
                }
                if (i < substrings.Length - 1)
                {
                    if (needComma)
                    {
                        sb.Append(", ");
                    }
                    sb.Append("'\"'");
                }
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
