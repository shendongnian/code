    using ZXing;
    using ZXing.Client.Result;
    using ZXing.Common;
    using ZXing.QrCode;
    ....
    var reader= new ZXing.QrCode.QRCodeReader();
    var barcodeBitmap = (Bitmap)Bitmap.FromFile(path);
    var result = reader.decode(barcodeBitmap);
    if (result != null)
    {
      var text = result.Text;
    }
