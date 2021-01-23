    public class CustomHandler : DelegatingHandler
    {
        public CustomHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }
    }
