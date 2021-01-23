    public void barcodescanner()
    {
        var scanner = new ZXing.Mobile.MobileBarcodeScanner();
        barcode =  scanner.Scan().Result;
    }
