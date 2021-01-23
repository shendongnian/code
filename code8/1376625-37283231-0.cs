        string base64String = await ToBase64Async(bitmap);
        public async Task<string> ToBase64Async(WriteableBitmap bitmap)
        {
            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                stream.Position = 0; 
                var reader = new DataReader(stream.AsInputStream());
                var bytes = new byte[stream.Length];
                await reader.LoadAsync((uint)stream.Length);
                reader.ReadBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
