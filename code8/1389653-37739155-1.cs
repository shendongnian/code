    using (var runspace = RunspaceFactory.CreateRunspace(InitialSessionState.CreateDefault()))
    {
        runspace.Open();
        PowerShell powerShellCommand = PowerShell.Create();
        powerShellCommand.Runspace = runspace;
        powerShellCommand.AddScript("Get-AppxPackage |?{!$_.IsFramework}");
        foreach (var result in powerShellCommand.Invoke())
        {
            try
            {
                if (result.Properties.Match("Name").Count > 0 &&
                    result.Properties.Match("InstallLocation").Count > 0)
                {
                    var name = result.Properties["Name"].Value;
                    var installLocation = result.Properties["InstallLocation"].Value;
                    Console.WriteLine(installLocation.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        runspace.Close();
    }
