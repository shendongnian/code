    public class DateLiteralJsonTextWriter : JsonTextWriter
    {
        public DateLiteralJsonTextWriter(TextWriter writer) : base(writer) { }
        public override void WriteValue(string value)
        {
            const string startToken = @"/Date(";
            const string replacementStartToken = @"\/Date(";
            const string endToken = @")/";
            const string replacementEndToken = @")\/";
            if (value != null && value.StartsWith(startToken) && value.EndsWith(endToken))
            {
                var sb = new StringBuilder();
                
                // Add the initial quote.
                sb.Append(QuoteChar);
                // Add the new start token.
                sb.Append(replacementStartToken);
                // Add any necessary escaping to the innards of the "/Date(.*)/" string.
                using (var writer = new StringWriter(sb))
                using (var jsonWriter = new JsonTextWriter(writer) { StringEscapeHandling = this.StringEscapeHandling, Culture = this.Culture, QuoteChar = '\"' })
                {
                    var content = value.Substring(startToken.Length, value.Length - startToken.Length - endToken.Length);
                    jsonWriter.WriteValue(content);
                }
                // Strip the embedded quotes from the above.
                sb.Remove(startToken.Length + 2, 1);
                sb.Remove(sb.Length - 1, 1);
                // Add the replacement end token and final quote.
                sb.Append(replacementEndToken);
                sb.Append(QuoteChar);
                // Write without any further escaping.
                WriteRawValue(sb.ToString());
            }
            else
            {
                base.WriteValue(value);
            }
        }
    }
