            string installPath = GetInstallLocation(RegistryView.Default); // try matching architecture
            if (installPath == null)
            {
                installPath = GetInstallLocation(RegistryView.Registry64); // explicitly try for 64-bit
            }
            if (installPath == null)
            {
                installPath = GetInstallLocation(RegistryView.Registry32); // explicitly try for 32-bit
            }
            if (installPath == null) // must not be installed
            {
                throw new InvalidOperationException("Program is not instlaled.");
            }
----
        public static string GetInstallLocation(RegistryView flavor)
        {
            const string subLocationPath = @"SOFTWARE\Microsoft\Some\Registry\Path\InstallLocation";
            object pathObj;
            try
            {
                RegistryKey view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, flavor);
                view32 = view32.OpenSubKey(subLocationPath);
                pathObj = view32.GetValue(null);
                return pathObj != null ? Convert.ToString(pathObj) : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
