      RegistryKey installed_versions =   Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
      string[] version_names = installed_versions.GetSubKeyNames();
      //version names start with 'v', eg, 'v3.5' which needs to be trimmed off    before conversion
      double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1), CultureInfo.InvariantCulture);
      int SP =  Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length     - 1]).GetValue("SP", 0));
     For .Net 4.5
     using System;
     using Microsoft.Win32;
     ...
     private static void Get45or451FromRegistry()
    {
    using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,    RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework  Setup\\NDP\\v4\\Full\\")) {
        int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
        if (true) {
            Console.WriteLine("Version: " + CheckFor45DotVersion(releaseKey));
         }
       }
     }
     ...
    // Checking the version using >= will enable forward compatibility,  
    // however you should always compile your code on newer versions of 
    // the framework to ensure your app works the same. 
    private static string CheckFor45DotVersion(int releaseKey)
    {
    if (releaseKey >= 393273) {
       return "4.6 RC or later";
    }
    if ((releaseKey >= 379893)) {
        return "4.5.2 or later";
    }
    if ((releaseKey >= 378675)) {
        return "4.5.1 or later";
    }
    if ((releaseKey >= 378389)) {
        return "4.5 or later";
    }
    // This line should never execute. A non-null release key should mean 
    // that 4.5 or later is installed. 
    return "No 4.5 or later version detected";
    }
