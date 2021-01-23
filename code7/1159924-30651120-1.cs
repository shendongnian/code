    var ie = new InternetExplorer();
    ie.Visible = false;
    ie.Navigate("about:blank");
    ie.Document.body.innerHTML = htmlTable;  //Yes, this is the correct casing
    ie.Document.body.createtextrange.execCommand("Copy");
    var xlExcel = new Application();
    xlExcel.Visible = true;
    var misValue = System.Reflection.Missing.Value;
    var xlWorkBook = xlExcel.WorkBooks.Add(misValue);
    var xlWorkSheet = (WorkSheet)xlWorkBook.Worksheets.get_Item(1);
    var range = (Range)xlWorkSheet.Cells[1, 1];
    range.Select();
    xlWorkSheet.Paste();
