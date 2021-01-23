    public class SomeFormatter : MediaTypeFormatter
    {
        public SomeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
        }
    ...
    }
