    public void Init()
    {
        _sharedBarCodeReader.Delegate = new BarCodeReaderDelegate(this);
    }
   
    private class BarCodeReaderDelegate : ICBarCodeReaderDelegate
    {
        public BarCodeReaderDelegate(BarCodeScanner barCodeScanner)
        {
            _barCodeScanner = barCodeScanner;
        }
        public override void BarcodeData(string data, BarCodeSymbologies type)
        {
            var handler = _barCodeScanner.BarCodeData;
            if (handler != null)
                handler(this, data);
        }
        public override void ConfigurationRequest() { }
        private readonly BarCodeScanner _barCodeScanner;
    }
