    /// <summary>Gets array of all possible shorter paths for provided path.</summary>
    /// <param name="path">The path to find alternate addresses for.</param>
    static string[] GetShortPaths(string path)
    {
        return GetUNCDrives()
            .Where(kvp => path.StartsWith(kvp.Value))
            .Select(kvp => Path.Combine(kvp.Key, path.Substring(kvp.Value.Length + 1)))
            .ToArray();
    }
    /// <summary>Gets all mapped drives and resolved paths.</summary>
    /// <returns>Dictionary: Key = drive, Value = resolved path</returns>
    static Dictionary<string, string> GetUNCDrives()
    {
        return DriveInfo.GetDrives()
            .Where(di => di.DriveType == DriveType.Network)
            .ToDictionary(di => di.RootDirectory.FullName
                        , di => GetUNCPath(di.RootDirectory.FullName.Substring(0, 2)));
    }
    /// <summary>Attempts to resolve the path/root to mapped value.</summary>
    /// <param name="path">The path to resolve.</param>
    static string GetUNCPath(string path)
    {
        if (path.StartsWith(@"\\"))
            return path;
        var mo = new ManagementObject(string.Format("Win32_LogicalDisk='{0}'", path));
        return Convert.ToUInt32(mo["DriveType"]) == (UInt32)DriveType.Network 
                ? Convert.ToString(mo["ProviderName"]) 
                : path;
    }
