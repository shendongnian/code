    namespace StackOverflow36216464
    {
        public class RawContentTypeMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {
                switch (contentType.ToLowerInvariant())
                {
                    case "text/plain":
                    case "application/json":
                        return WebContentFormat.Json;
                    case "application/xml":
                        return WebContentFormat.Xml;
                    default:
                        return WebContentFormat.Default;
                }
            }
        }
    }
