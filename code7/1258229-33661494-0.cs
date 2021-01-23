    using (var hklmKey = Microsoft.Win32.Registry.LocalMachine)
    using (var subKey = hklmKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
    {
         if (subKey != null)
         {
             string release = subKey.GetValue("ReleaseId") as string;
             if (release != null)
                 retVal += " Version " + release;
         }
    }
