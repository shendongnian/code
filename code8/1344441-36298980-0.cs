    // First Text to QR Code as an image
    public byte[] ToQRAsGif(string content)
    {
        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Height = this._h,
                Width = this._w,
                Margin = 2
            }
        };
            
        using (var bitmap = barcodeWriter.Write(content))
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Gif);
            stream.Position = 0;
            return stream.GetBuffer();
        }
    }
    // From Text to QR Code as base64 string
    public string ToQRAsBase64String(string content)
    {     
        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Height = _h,
                Width = _w,
                Margin = 2
            }
        };
         
        using (var bitmap = barcodeWriter.Write(content))
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Gif);
            return String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(stream.ToArray()));
        }
    }
