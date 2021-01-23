    bool printerIsOnline = true;
    string printerName = "MyPrinterName";
    string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
    ManagementObjectSearcher searcherPrinters = new ManagementObjectSearcher(query);
    foreach (ManagementObject printer in searcherPrinters.Get())
    {
        printerIsOnline = !printer["WorkOffline"].ToString().Equals("True");
    }
