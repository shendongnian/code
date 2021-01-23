    private void button1_Click(object sender, EventArgs e)
    {
        string path = @"c:\temp\test\Book1.xlsx";
        var xlApp = new Microsoft.Office.Interop.Excel.Application();
        Workbook wb = xlApp.Workbooks.Open(path);
    
        string xmlString =
        "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
        "<employees xmlns=\"http://schemas.microsoft.com/vsto/samples\">" +
            "<employee>" +
                "<name>Karina Leal</name>" +
                "<hireDate>1999-04-01</hireDate>" +
                "<title>Manager</title>" +
            "</employee>" +
        "</employees>";
     
        wb.CustomXMLParts.Add(xmlString, Type.Missing);
        wb.Save();
    }
