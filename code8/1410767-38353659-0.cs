    var text = "Folder Names\n" + string.Join("\n", Namelist);    // or "\r\n"
    System.Windows.Forms.Clipboard.SetText(text);
    var xl = new Microsoft.Office.Interop.Excel.Application();
    var wb = excel.Workbooks.Add();
    xl.ActiveCell.PasteSpecial();     // or just xl.ActiveSheet.Paste()
