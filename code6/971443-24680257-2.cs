    var key = @"Software\Microsoft\VisualStudio\" + "12.0" + @"_Config\SourceControlProviders";
    var subkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key);
    var providerNames = subkey.GetSubKeyNames().Dump();
    var dict = new Dictionary<Guid, String>();
    foreach (var provGuidString in subkey.GetSubKeyNames())
    {
 	    var provName = (string)subkey.OpenSubKey(provGuidString).GetValue("");
 	    dict.Add(Guid.Parse(provGuidString), provName);
    }
