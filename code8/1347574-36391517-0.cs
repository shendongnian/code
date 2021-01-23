    /// <summary>
    /// Sample code: Show the additional registered decoders 
    /// </summary>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var additionalDecoders = GetAdditionalDecoders();
        foreach(var additionalDecoder in additionalDecoders)
        {
            MessageBox.Show(additionalDecoder.FriendlyName + ":" + additionalDecoder.FileExtensions);
        }
    }
    /// <summary>
    /// GUID of the component registration group for WIC decoders
    /// </summary>
    private const string WICDecoderCategory = "{7ED96837-96F0-4812-B211-F13C24117ED3}";
    /// <summary>
    /// Represents information about a WIC decoder
    /// </summary>
    public struct DecoderInfo
    {
        public string FriendlyName;
        public string FileExtensions;
    }
    /// <summary>
    /// Gets a list of additionally registered WIC decoders
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<DecoderInfo> GetAdditionalDecoders()
    {
        var result = new List<DecoderInfo>();
        string baseKeyPath;
        
        // If we are a 32 bit process running on a 64 bit operating system, 
        // we find our config in Wow6432Node subkey
        if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
        {
            baseKeyPath = "Wow6432Node\\CLSID";
        }
        else
        {
            baseKeyPath = "CLSID";
        }
        
        RegistryKey baseKey = Registry.ClassesRoot.OpenSubKey(baseKeyPath, false);
        if (baseKey != null)
        {
            var categoryKey = baseKey.OpenSubKey(WICDecoderCategory + "\\instance", false);
            if (categoryKey != null)
            {
                // Read the guids of the registered decoders
                var codecGuids = categoryKey.GetSubKeyNames();
                foreach (var codecGuid in codecGuids)
                {
                    // Read the properties of the single registered decoder
                    var codecKey = baseKey.OpenSubKey(codecGuid);
                    if (codecKey != null)
                    {
                        DecoderInfo decoderInfo = new DecoderInfo();
                        decoderInfo.FriendlyName = Convert.ToString(codecKey.GetValue("FriendlyName", ""));
                        decoderInfo.FileExtensions = Convert.ToString(codecKey.GetValue("FileExtensions", ""));
                        result.Add(decoderInfo);
                    }
                }
            }
        }
        
        return result;
    }
