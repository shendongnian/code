    public class PreserveQuotesXmlTextWriter : XmlTextWriter
    {
        private static readonly string[] quoteEntites = { "&apos;", "&quot;" };
        private static readonly char[] quotes = { '\'', '"' };
        private bool isInsideAttribute;
        public PreserveQuotesXmlTextWriter(string filename) : base(filename, null)
        {            
        }
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            isInsideAttribute = true;
            base.WriteStartAttribute(prefix, localName, ns);
        }
        private void WriteStringWithReplace(string text)
        {
            string[] textSegments = text.Split(quotes);
            if (textSegments.Length > 1)
            {
                for (int pos = -1, i = 0; i < textSegments.Length; ++i)
                {
                    base.WriteString(textSegments[i]);
                    pos += textSegments[i].Length + 1;
                    if (pos != text.Length)
                        base.WriteRaw(text[pos] == quotes[0] ? quoteEntites[0] : quoteEntites[1]);
                }
            }
            else base.WriteString(text);
        }
        public override void WriteString(string text)
        {
            if (isInsideAttribute)
                base.WriteString(text);
            else
                WriteStringWithReplace(text);
            isInsideAttribute = false;
        }
    }
