    static class Ps
    {
        private const string RemoteHost = "ADMINSERVER.DOMAIN1.co.uk";
        private static string _errors;
        /// <summary>
        /// Executes the given command over a remote powershell session
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Collection<PSObject> RemoteCommand(string args)
        {
            SupportMi.Trace = $"Remote Command({args}) {{";
            var script = BuildScript(args);
            var results = Execute(script);
            
            SupportMi.Trace = $"RES: {results[0]} ERR: {_errors} }}";
            return results;
        }
        /// <summary>
        /// Takes a complete script and executes it over a powershell Runspace. In this case it is being
        /// sent to the server, and the results of the execution are checked for any errors. 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        private static Collection<PSObject> Execute(string script)
        {
            var results = new Collection<PSObject>();
            // Using a runspace
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                using (var pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript(script);
                    try
                    {
                        results = pipeline.Invoke();
                        var errors = pipeline.Error.Read(pipeline.Error.Count);
                        foreach (var error in errors)
                        {
                            _errors += error;
                        }
                    }
                    catch (Exception ex)
                    {
                        results.Add(new PSObject(ex.Message));
                        SupportMi.Trace = ex.Message;
                    }
                }
            }
            return results;
        }
        /// <summary>
        /// Takes a string argument to be sent to the remote powershell session and arranges it in the correct format,
        /// ready to be sent to the server.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static string BuildScript(string args)
        {
            // Build the script
            var script = Creds() + Environment.NewLine +
                        $"Invoke-Command -session $sessions -ScriptBlock {{ {args} /U DOMAIN1\\adminusername /P adminpassword }}" + Environment.NewLine +
                        "Remove-PSSession -Session $sessions" + Environment.NewLine +
                        "exit";
            return script;
        }
        /// <summary>
        /// Returns the credentials for a remote PowerShell session in the form 
        /// of a few lines of PowerShell script. 
        /// </summary>
        /// <returns></returns>
        private static string Creds()
        {
            return "$pw = convertto-securestring -AsPlainText -Force -String \"adminpassword\"" + Environment.NewLine +
                   "$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist \"DOMAIN1\\adminusername\",$pw" + Environment.NewLine +
                   $"$sessions = New-PSSession -ComputerName {RemoteHost} -credential $cred";
        }
    }
