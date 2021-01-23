    private async Task<InMemoryRandomAccessStream> CreateInMemoryImageStream(Color fillColor, uint heightInPixel, uint widthInPixel)
        {
            var stream = new InMemoryRandomAccessStream();
            
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId,stream);
            List<Byte> bytes = new List<byte>();
            for (int x = 0; x < widthInPixel; x++)            
            {
                for (int y = 0; y < heightInPixel; y++)
                {
                    bytes.Add(fillColor.R);
                    bytes.Add(fillColor.G);
                    bytes.Add(fillColor.B);
                    bytes.Add(fillColor.A);                   
                }   
            }
            encoder.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Ignore, widthInPixel, heightInPixel, 96, 96, bytes.ToArray());
            await encoder.FlushAsync();
            return stream;
        }
