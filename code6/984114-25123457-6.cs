     public class WebImageWrapper : IWebImage
     {
        private readonly WebImage _instance;
        public WebImageWrapper(byte[] data)
        {
            _instance = new WebImage(data);
        }
        public WebImageWrapper(WebImage image)
        {
            _instance = image;
        }
        public void Write(string requestedFormat = null)
        {
            _instance.Write(requestedFormat);
        }
        public string ImageFormat { get { return _instance.ImageFormat; } }
        public int Width { get { return _instance.Width; } }
        public int Height { get { return _instance.Height; } }
        public byte[] GetBytes(string requestedFormat = null)
        {
            return _instance.GetBytes(requestedFormat);
        }
        public IWebImage Resize(int width, int height, bool preserveAspectRatio = true, bool preventEnlarge = false)
        {
            return new WebImageWrapper(_instance.Resize(width, height, preserveAspectRatio, preventEnlarge));
        }
    }
