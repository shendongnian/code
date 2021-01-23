            private void RunPowerShell(string[] hosts)
            {
                Parallel.ForEach(hosts, (host) => {
                    var remoteComputer = new Uri(String.Format("{0}://{1}:5985/wsman", "http", hosts));
                    var connection = new WSManConnectionInfo(remoteComputer);
                    var runspace = RunspaceFactory.CreateRunspace(connection);
                    runspace.Open();
    
                    for (int ii = 0; ii < powerShellfiles.ToArray().Length; ii++)
                    {
                        using (PowerShell ps = PowerShell.Create())
                        {
                            ps.Runspace = runspace;
                            //ps.AddScript(powerShellfiles[ii]);
                            ps.AddScript(powerShellfiles[ii]);
                            IAsyncResult async = ps.BeginInvoke();
                            List<string> aa = ps.EndInvoke(async).SelectMany(x => x.Properties.Where(y => y.Name == "rec_num").Select(z => z.Value.ToString())).ToList();
                            keysFromhost.AddRange(aa);
                        }
    
                    };
                });
            }
