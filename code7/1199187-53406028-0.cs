      public class ImageWriterHelper
        {
            public enum ImageFormat
            {
                Bmp,
                Jpeg,
                Gif,
                Tiff,
                Png,
                Unknown
            }
    
        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");
            var gif = Encoding.ASCII.GetBytes("GIF");
            var png = new byte[] { 137, 80, 78, 71 };
            var tiff = new byte[] { 73, 73, 42 };
            var tiff2 = new byte[] { 77, 77, 42 };
            var jpeg = new byte[] { 255, 216, 255, 224 };
            var jpeg2 = new byte[] { 255, 216, 255, 225 };
    
            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.Bmp;
    
            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.Gif;
    
            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.Png;
    
            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.Tiff;
    
            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.Tiff;
    
            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.Jpeg;
    
            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.Jpeg;
    
            return ImageFormat.Unknown;
        }
    }
