    //use gaussian filter to remove noise
    var gFilter = new GaussianBlur(2);
    image = gFilter.ProcessImage(image);
                       
    var options = new DecodingOptions { PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE }, TryHarder = true };
        
    using (image)
    {
        //use GlobalHistogramBinarizer for best result
        var reader = new BarcodeReader(null, null, ls => new GlobalHistogramBinarizer(ls)) { AutoRotate = false, TryInverted = false, Options = options };
        var result = reader.Decode(image);
        reader = null;
                        
       return result;
    }`
