    static void Main(string[] args)
        {
            object misValue = System.Reflection.Missing.Value;
            Type excelApplication = Type.GetTypeFromProgID("Excel.Application");
            dynamic excel = Activator.CreateInstance(excelApplication);
            dynamic xlWorkBook = excel.Workbooks.Add(misValue);
            dynamic SourceSheets = xlWorkBook.Worksheets[1];
            Type IeType = Type.GetTypeFromProgID("InternetExplorer.Application");
            dynamic Ie = Activator.CreateInstance(IeType);
            SourceSheets.Range("A1").Value = "<b>This is <i>html text</i></b> that <font>could contain</font> any type of html;<br/>";
            Ie.Visible = false;
            Ie.Navigate("about:blank");
            Ie.document.body.InnerHTML = SourceSheets.Range("A1").Value;
            Ie.document.body.createtextrange.execCommand("Copy");
            SourceSheets.Paste(SourceSheets.Range("A1"));
            Ie.Quit();
            xlWorkBook.SaveAs("test1", misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
        }
