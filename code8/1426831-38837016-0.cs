    using System.Management.Automation;
    using System.Collections.ObjectModel;
    public class Test
    {
        public static Collection<PSObject> RunCommand()
        {
            PowerShell psHost = PowerShell.Create();
            Collection<PSObject> output = psHost.AddCommand("Get-Process").AddArgument("powershell").Invoke();
            if (psHost.HadErrors)
            {
                foreach (ErrorRecord error in psHost.Streams.Error)
                {
                    throw error.Exception;
                }
                return null;
            }
            else
            {
                return output;
            }
        }
    }
