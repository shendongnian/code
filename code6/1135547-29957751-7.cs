    public void Init()
    {
        _sharedBarCodeReader.BarcodeData += OnBarcodeData;
    }
   
    private void OnBarcodeData(object sender, BarcodeDataEventArgs e)
    {
        var barcode = Convert.ToString(sender); // this maps to string data
        //BarCodeSymbologies is in BarcodeDataEventArgs
        var handler = BarCodeData;
        if (handler != null)
            handler(this, barcode);
    }
