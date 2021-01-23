    // Property
    public WriteableBitmap QRImage { get; set; }
    
    // Function to call
    private void SetQR()
    {
        var options = new QrCodeEncodingOptions()
        {
            DisableECI = true,
            CharacterSet = "UTF-8",
            Width = 1000,
            Height = 1000
        };
    
        BarcodeWriter writer = new BarcodeWriter();
        writer.Format = BarcodeFormat.QR_CODE;
        writer.Options = options;
        QRImage= writer.Write(SelectedEvent.GetQrString());
    }
