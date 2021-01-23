    public byte[] GenerateQrImage(string content, int width, int height)
    {
        var options = new QrCodeEncodingOptions
        {
            Height = height,
            Width = width,
            Margin = 0,
            PureBarcode = true
        };
    
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = options
        };
    
        // Generate bitmap
        var bitmap = writer.Write(content);
        if (bitmap != null)
        {
            // Get bytes from bitmap
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                return stream.ToArray();
            }
        }
    
        return null;
    }
