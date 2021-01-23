    public static class ByteArrayExtensions
    {
        public static async Task<BitmapImage> AsBitmapImageAsync(this byte[] byteArray)
        {
            if (byteArray == null) return null;
    
            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(byteArray.AsBuffer());
                var image = new BitmapImage();
                stream.Seek(0);
                image.SetSource(stream);
                return image;
            }
        }
    }
