    var receiptSheet = package.Workbook.Worksheets.Add("Receipt");
    int rowIndex = 1;
    int columnIndex = 1;
    
    var base64String =  fromDataBase;
    base64String = base64String.Replace(" ", "+");
    int mod4 = base64String.Length % 4;
    if (mod4 > 0)
    {
        base64String += new string('=', 4 - mod4);
    }
    
    var image = Base64StringToBitmap(base64String);
    ExcelPicture picture = null;
    if (image != null)
    {
        picture = receiptSheet.Drawings.AddPicture("pic" + rowIndex.ToString() + columnIndex.ToString(), image);
        picture.From.Column = columnIndex;
        picture.From.Row = rowIndex;
        picture.SetSize(600, 400);
    }
    package.Save();
    
    private Bitmap Base64StringToBitmap(string base64String)
    {
        var bitmapData = Convert.FromBase64String(FixBase64ForImage(base64String));
        var streamBitmap = new System.IO.MemoryStream(bitmapData);
        var bitmap = new Bitmap((Bitmap)Image.FromStream(streamBitmap));
        return bitmap;
    }
    
    private string FixBase64ForImage(string Image)
    {
       var sbText = new System.Text.StringBuilder(Image, Image.Length);
       sbText.Replace("\r\n", String.Empty); 
       sbText.Replace(" ", String.Empty);
       return sbText.ToString();
    }
