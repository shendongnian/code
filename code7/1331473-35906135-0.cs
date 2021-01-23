    if (source != null)
    {
        int count = 0;
        int stride = (source.PixelWidth * source.Format.BitsPerPixel + 7) / 8;
        byte[] pixels = new byte[source.PixelHeight * stride];
        source.CopyPixels(pixels, stride, 0);
        for (int y = 0; y < source.PixelHeight; y = y + 2)
        {
            for (int x = 0; x < source.PixelWidth; x = x + 2)
            {
                int index = y * stride + 4 * x;
                count = index;
                
                int bufsize = source.PixelHeight * stride;
                System.Diagnostics.Debug.WriteLine($"bufsize={bufsize}, index={index}, x={x}, y={y}");
                System.Diagnostics.Debug.Assert((index+3) <= bufsize);
                byte red = pixels[index];
                byte green = pixels[index + 1];
                byte blue = pixels[index + 2];
                byte alpha = pixels[index + 3];
            }
        }
        MessageBox.Show("Array Length, pixels: " + pixels.Count() + "," + count);
    }
