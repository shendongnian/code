	var fmts = new List<BarcodeFormat> {BarcodeFormat.EAN_13, BarcodeFormat.All_1D};
            
    BarcodeReader reader = new BarcodeReader
    {
        AutoRotate = true,
        TryInverted = true,
        Options =
        {
            PossibleFormats = fmts,
            TryHarder = true,
            ReturnCodabarStartEnd = true,
            PureBarcode = false
        }
    };
    Result result = reader.Decode(new Bitmap(@"C:\Users\me\Desktop\7.jpg"));
    if (result != null)
    {
        Console.WriteLine(result.BarcodeFormat);
        Console.WriteLine(result.Text);
    }
    else
    {
        Console.Out.WriteLine("Missed");
    }
