    const string driveLetter = "Z";
    const string targetLocation = "\\\\192.168.0.111\\e";
    string wmiQuery = string.Format("SELECT ProviderName FROM Win32_MappedLogicalDisk WHERE Name = '{0}:'", driveLetter);
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
    ManagementObjectCollection queryResults = searcher.Get();
    bool driveMatched = false;
    foreach (ManagementObject queryResult in queryResults)
    {
        string providerName = queryResult["ProviderName"].ToString();
        if (providerName.ToLowerInvariant() == targetLocation.ToLowerInvariant())
        {
            driveMatched = true;
            break;
        }
    }
    if (!driveMatched)
    {
        // No match, do some error handling
    }
