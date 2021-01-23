    var key = Microsoft.Win32.RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
    key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
    if (key != null)
    {
        DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
        object objValue = key.GetValue("InstallDate");
        string stringValue = objValue.ToString();
        Int64 regVal = Convert.ToInt64(stringValue);
        DateTime installDate = startDate.AddSeconds(regVal);
    }
