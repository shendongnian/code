    // Variable
    string[] filesDirectory = Directory.GetFiles(Server.MapPath("~/Image"));
    int count = 0;
    
    foreach(string img in filesDirectory)
    {
        count++;
        ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Worksheet - " + count);
        // img variable actually is your image path
        System.Drawing.Image myImage = System.Drawing.Image.FromFile(img);
        var pic = ws.Drawings.AddPicture("NAME", myImage);
                
        // Row, RowoffsetPixel, Column, ColumnOffSetPixel
        pic.SetPosition(1, 0, 2, 0);
    }
