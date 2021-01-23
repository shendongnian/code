    var text = "Folder Names\n" + string.Join("\n", Namelist);    // or "\r\n"
    System.Windows.Forms.Clipboard.SetText(text);
    var xl = new Microsoft.Office.Interop.Excel.Application();
    var wb = xl.Workbooks.Add();
    var ws = xl.ActiveSheet as Worksheet;
    ws.Range("A1").PasteSpecial();
    xl.Visible = true;
