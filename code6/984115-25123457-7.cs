    public class WebImageFactory : IWebImageFactory
    {
        public IWebImage Get(byte[] data)
        {
            return new WebImageWrapper(data);
        }
    }
