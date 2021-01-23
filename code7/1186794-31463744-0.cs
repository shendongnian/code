        private async Task<string> generateBase64Bitmap()
        {
            // Initialization  
            try
            {
                // Initialization.  
                Size canvasSize = this.Display.RenderSize;
                Point defaultPoint = this.Display.RenderTransformOrigin;
                // Sezing to output image dimension.  
                this.Display.Measure(canvasSize);
                this.Display.UpdateLayout();
                this.Display.Arrange(new Rect(defaultPoint, canvasSize));
                // Convert canvas to bmp.  
                var bmp = new RenderTargetBitmap();
                await bmp.RenderAsync(this.Display, (int)(this.Display.ActualWidth / 4), (int)(this.Display.ActualHeight / 4));
                // Setting.  
                var bitmap = (RenderTargetBitmap) bmp;
                //var bytes = (await bitmap.GetPixelsAsync()).ToArray();
                return await toBase64(bitmap);
            }
            catch (Exception ex)
            {
                //this.ShowMessage(ex.ToString(), "Error");
            }
            return string.Empty;
        }
        private async Task<string> toBase64(RenderTargetBitmap bmp)
        {
            var img = (await bmp.GetPixelsAsync()).ToArray();
            var encoded = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(
                BitmapEncoder.PngEncoderId, encoded);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight,
                (uint)bmp.PixelWidth, (uint)bmp.PixelHeight, 96, 96, img);
            await encoder.FlushAsync();
            encoded.Seek(0);
            //read bytes
            var bytes = new byte[encoded.Size];
            await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);
            return Convert.ToBase64String(bytes);
        }
