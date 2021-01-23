        public byte[] ConvertToBytes(BitmapImage bitmapImage)
        {
            if (bitmapImage != null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memStream);
                return memStream.GetBuffer();
            }
            return null;
        }
