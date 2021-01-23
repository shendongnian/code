    var workbook = ExcelFile.Load("Workbook.xls");
    workbook.Worksheets.ActiveWorksheet = workbook.Worksheets[0];
    
    var options = new CsvSaveOptions(CsvType.TabDelimited);
    options.Encoding = new UTF8Encoding(false);
    
    using (var stream = new MemoryStream())
    {
        workbook.Save(stream, options);
    
        string worksheetAsText = options.Encoding.GetString(stream.ToArray());
        // Do something with "worksheetAsText" ...
    }
