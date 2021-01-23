        public static Image ByteArrayToImage(Byte[] imageBytes)
        {
            var stream = new MemoryStream(imageBytes);
            {
                var frame = new BitmapImage();
                frame.BeginInit();
                frame.CacheOption = BitmapCacheOption.OnLoad;
                frame.StreamSource = stream;
                frame.EndInit();
                frame.Freeze();
                Image newImage = new Image() { Source = frame };
                return newImage;
            }
        }
