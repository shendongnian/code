    ProjectInstaller projectInstaller = new ProjectInstaller();
                string[] cmdline = { string.Format("/assemblypath={0} /myParam", Assembly.GetExecutingAssembly().Location) };
                projectInstaller.Context = new InstallContext(null, cmdline);
    
                System.Collections.Specialized.ListDictionary state = new System.Collections.Specialized.ListDictionary();
                projectInstaller.Install(state);
