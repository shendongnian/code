        public static BitmapImage AsBitmapImage(this byte[] byteArray)
        {
            if (byteArray != null)
            {
                using (var stream = new InMemoryRandomAccessStream())
                {
                    stream.WriteAsync(byteArray.AsBuffer()).GetResults(); 
                              // I made this one synchronous on the UI thread;
                              // this is not a best practice.
                    var image = new BitmapImage();
                    stream.Seek(0);
                    image.SetSource(stream);
                    return image;
                }
            }
            return null;
        }
