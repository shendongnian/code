    string searchQuery = "SELECT * FROM Win32_Printer";
    ManagementObjectSearcher searchPrinters = new 
    ManagementObjectSearcher(searchQuery);
    ManagementObjectCollection printerCollection = searchPrinters.Get();
    
    foreach (ManagementObject printer in printerCollection)
    {
        PropertyDataCollection printerProperties = printer.Properties;
        foreach (PropertyData property in printerProperties)
        {
            if (property.Name == "KeepPrintedJobs")
            {
                printerProperties[property.Name].Value = true;
            }
        }
        printer.Put();
    }
