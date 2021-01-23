    Color4 GetPixel(Bitmap image, int x, int y, RenderTarget renderTarget) {
            var deviceContext2d = renderTarget.QueryInterface<DeviceContext>();
            var bitmapProperties = new BitmapProperties1();
            bitmapProperties.BitmapOptions = BitmapOptions.CannotDraw | BitmapOptions.CpuRead;
            bitmapProperties.PixelFormat = image.PixelFormat;
            var bitmap1 = new Bitmap1(deviceContext2d, new Size2((int)image.Size.Width, (int)image.Size.Height), bitmapProperties);
            bitmap1.CopyFromBitmap(image);
            var map = bitmap1.Map(MapOptions.Read);
            var size = (int)image.Size.Width * (int)image.Size.Height * 4;
            byte[] bytes = new byte[size];
            Marshal.Copy(map.DataPointer, bytes, 0, size);
            bitmap1.Unmap();
            bitmap1.Dispose();
            deviceContext2d.Dispose();
            var position = (y * (int)image.Size.Width + x) * 4;
            return new Color4(bytes[position], bytes[position + 1], bytes[position + 2], bytes[position + 3]);
        }
