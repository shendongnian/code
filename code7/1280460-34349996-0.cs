     PowerShell powershell = PowerShell.Create();
                        //RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                        //Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration)
                        using (Runspace runspace = RunspaceFactory.CreateRunspace())
                        {
                            runspace.Open();
                            //RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
                            //scriptInvoker.Invoke("Set-ExecutionPolicy Unrestricted");
                            powershell.Runspace = runspace;
                           //powershell.Commands.AddScript("Add-PsSnapin Microsoft.SharePoint.PowerShell");
                            System.IO.StreamReader sr = new System.IO.StreamReader(scriptfilepath);
                            powershell.AddScript(sr.ReadToEnd());
                            //powershell.AddCommand("Out-String");
                            var results = powershell.Invoke();
                            if (powershell.Streams.Error.Count > 0)
                            {
                                // error records were written to the error stream.
                                // do something with the items found.
                            }
                        }
