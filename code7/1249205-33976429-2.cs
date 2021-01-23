    public async Task<string> GetOSVersion()
    {
        var version = await WindowsStoreSystemInfo.GetWindowsVersionAsync();
        string result = String.Format("{0} {1}", MachineInfo.OperatingSystem, version);
        return result;
    }
