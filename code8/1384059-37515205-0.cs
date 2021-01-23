    public class SOFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            output.Write("{");
            foreach (var p in logEvent.Properties)
            {
                output.Write("\"{0}\" : {1}, ", p.Key, p.Value);
            }
            output.Write("}");
        }
    }
