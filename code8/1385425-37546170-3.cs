    public static Bitmap GenerateQrCode(string url, System.Drawing.Color darkColor, System.Drawing.Color lightColor, int size) {
        var encoder = new QrEncoder(ErrorCorrectionLevel.L);
        var code = encoder.Encode(url);
        if (size % code.Matrix.Width != 0 || size % code.Matrix.Height != 0)
            throw new InvalidOperationException("Width/Height not divisible with size");
        var multiplier = size / code.Matrix.Width;
        var tempBmp = new Bitmap(size, size);
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                var originalX = x / multiplier;
                var originalY = y / multiplier;
                if (code.Matrix.InternalArray[originalX, originalY])
                    tempBmp.SetPixel(x, y, darkColor);
                else
                    tempBmp.SetPixel(x, y, lightColor);
            }
        }
        return tempBmp;
    }
