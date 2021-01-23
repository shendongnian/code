            InitialSessionState initial = InitialSessionState.CreateDefault();
            initial.ImportPSModule(new string[] { "C:\\Program Files\\Microsoft Dynamics NAV\\80\\Service\\NavAdminTool.ps1" });
            Runspace runspace = RunspaceFactory.CreateRunspace(initial);
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            ps.Commands.AddCommand("Get-NAVTenant");
            ps.Commands.AddParameter("-ServerInstance", "objectupgrade");                        
            foreach (PSObject result in ps.Invoke())
            {
                Console.WriteLine(result.Properties["DatabaseServer"].Value);
            }
            Console.Read();
            Console.ReadKey();
