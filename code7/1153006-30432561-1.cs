    public ActionResult ExcelRead()
    {
        string pathToExcelFile = ""
        + @"C:\MyFolder\ProjectFolder\sample.xlsx";
        string sheetName = "Sheet1";
        var excelFile = new ExcelQueryFactory(pathToExcelFile);
        var getData = from a in excelFile.Worksheet(sheetName) select a;
        string getInfo = String.Empty;
        foreach (var a in getData)
        {
            getInfo += "Name: "+ a["Name"] +"; Amount: "+ a["Amount"] +">>   ";
            
        }
        ViewBag.excelRead = getInfo;
        return View();
    }
