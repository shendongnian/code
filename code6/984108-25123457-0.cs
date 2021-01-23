     public interface IWebImage
     { 
        void Write(string requestedFormat = null);
        string ImageFormat { get; }
        int Width { get; }
        int Height { get; }
        byte[] GetBytes(string requestedFormat = null);
        
        IWebImage Resize(int width, int height, bool preserveAspectRatio = true, bool preventEnlarge = false);
    }
