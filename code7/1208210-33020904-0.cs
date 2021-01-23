    public sealed class AssemblyResolveHandler
    {
        const string LIBRARY_PATH = @"C:\...\...\";
        public static Assembly ResolveEventHandler(object sender, System.ResolveEventArgs e)
        {
            Assembly a = null;
            string assemblyName = e.Name.Substring(0, e.Name.IndexOf(","));
            //Look for the DLL assembly
            a = FindAssembly(LIBRARY_PATH, assemblyName + ".dll");
            if (a == null)
            {   //If no DLL assembly was found, look for an EXE assembly.
                a = FindAssembly(eofSharedFolder, assemblyName + ".exe");
            }
            return a;
        }
        public static Assembly FindAssembly(string appFolder, string fileName, out string logReturn)
        {
            Assembly rtnAssembly = null;
            string targetFolder = appFolder;
            //some dll's are hidden in x64 folders or x86 folders
            if (Environment.Is64BitOperatingSystem)
                targetFolder += "\x64";
            else
                targetFolder += "\x86";
            string fullCurrentLocation = System.IO.Directory.GetCurrentDirectory() + @"\" + fileName;
            string fullAppLocation = Path.GetFullPath(appFolder) + @"\" + fileName;
            string fullAltLocation = Path.GetFullPath(targetFolder) + @"\" + fileName;
            //make sure it's not in the current folder
            if (File.Exists(fullCurrentLocation))
            {
                rtnAssembly = Assembly.LoadFrom(fullCurrentLocation);
            }
            else if (File.Exists(fullAppLocation))
            {
                rtnAssembly = Assembly.LoadFrom(fullAppLocation);
            }
            else if (File.Exists(fullAltLocation))
            {
                rtnAssembly = Assembly.LoadFrom(fullAltLocation);
            }
        
            return rtnAssembly;
        }
    }
