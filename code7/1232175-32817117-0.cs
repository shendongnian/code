    try
    {
        string PrinterJobs = "SELECT * FROM Win32_PrintJob";
        ManagementObjectSearcher FindPrintJobs = new ManagementObjectSearcher(PrinterJobs);
        ManagementObjectCollection prntJobCollection = FindPrintJobs.Get();
        foreach (ManagementObject prntJob in prntJobCollection)
        {
    		string jobName = prntJob.Properties["Name"].Value.ToString();
    		string documentName = prntJob.Properties["Document"].Value.ToString();
    		string nbcopie = prntJob.Properties["TotalPages"].Value.ToString();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
