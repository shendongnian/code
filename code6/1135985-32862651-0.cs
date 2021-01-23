    // Open excel document
    var path = @"c:\path\to\my\doc.xlsx";
    Microsoft.Office.Interop.Excel.Application _xlApp;
    Microsoft.Office.Interop.Excel.Workbook _xlBook;
    _xlApp = new Microsoft.Office.Interop.Excel.Application();
    _xlBook = _xlApp.Workbooks.Open(path);
    _xlBook.Activate();
    var printer = @"EPSON LQ-690 ESC/P2";
    var port = String.Empty;
    // Find correct printerport
    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path))
    {
        if (key != null)
        {
            object value = key.GetValue(printer);
            if (value != null)
            {
                string[] values = value.ToString().Split(',');
                if (values.Length >= 2) port = values[1];
            }
        }
    }
    // Set ActivePrinter if not already set
    if (!_xlApp.ActivePrinter.StartsWith(printer))
    {
        // Get current concatenation string ('on' in enlgish, 'op' in dutch, etc..)
        var split = _xlApp.ActivePrinter.Split(' ');
        if (split.Length >= 3)
        {
            _xlApp.ActivePrinter = String.Format("{0} {1} {2}",
                printer, 
                split[split.Length - 2], 
                port);
        }
    }
    // Print document
    _xlBook.PrintOutEx();
