    public abstract class MyConstants
    {
        public class HttpMethods
        {
            public const string Put = "PUT";
            public const string Post = "POST";
            public const string Get = "GET";
        }
    
        public const int MaximumImageUploadSize = 3 * 1024 * 1024; // 3MB
        public const int MaximumDocumentUploadSize = 5 * 1024 * 1024; // 5MB
    	public const HttpMethods HttpMethodObj;
    }
