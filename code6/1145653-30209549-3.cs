            var config = RunspaceConfiguration.Create();
            PSSnapInException warning;
            config.AddPSSnapIn("Microsoft.Dynamics.Nav.Management", out warning);
            using (Runspace runspace = RunspaceFactory.CreateRunspace(config))
            {
                runspace.Open();
                using (var ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;
                    ps.AddCommand("Get-NAVTenant");
                    ps.AddParameter("ServerInstance", "ObjectUpgrade");
                    Collection<PSObject> results = ps.Invoke();
                    foreach (PSObject obj in results)
                    {
                        Console.WriteLine(obj.Properties["DatabaseServer"].Value);                            
                    }
                    Console.Read();
                    Console.ReadKey();
                }
            }
