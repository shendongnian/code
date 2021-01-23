        static void Main(string[] args)
        {
            bool installing = true;
            string asmPath = "";
            if (!ParseInput(args, ref installing, ref asmPath))
            {
                PrintUsage();
                return;
            }
            Assembly myAssem = Assembly.Load(File.ReadAllBytes(asmPath));
            Console.WriteLine(myAssem.FullName);
            
            AssemblyInstaller wmi_installer = new AssemblyInstaller(myAssem, null);
            wmi_installer.Install(null);
            wmi_installer.Commit(null);
        }
