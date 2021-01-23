        static void Main(string[] args)
        {
            bool installing = true;
            bool installable = false;
            string asmPath = "";
            if (!ParseInput(args, ref installing, ref asmPath))
            {
                PrintUsage();
                return;
            }
            IDictionary mySavedState = new Hashtable();
            Assembly myAssem = Assembly.Load(File.ReadAllBytes(asmPath));
            Console.WriteLine(myAssem.FullName);
            AssemblyInstaller wmi_installer = new AssemblyInstaller(myAssem, null);
            
            if (installing)
            {
                try
                {
                    AssemblyInstaller.CheckIfInstallable(asmPath);
                    installable = true;
                }
                catch (Exception)
                {
                    installable = false;
                }
                if (installable)
                {
                    mySavedState.Clear();
                    try
                    {
                        wmi_installer.Install(mySavedState);
                        wmi_installer.Commit(mySavedState);
                    }
                    catch (Exception)
                    {
                        wmi_installer.Rollback(mySavedState);
                    }
                }
            }
            else
            {
                try
                {
                    wmi_installer.Uninstall(null);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Uninstall failed due to: " + e.Message);
                }
            }
        }
