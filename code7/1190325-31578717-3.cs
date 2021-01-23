    using System.Management.Automation;
    using System.Collections.ObjectModel;
    using System.Management.Automation.Runspaces;
    using System.Diagnostics;
    
    namespace PowerShell
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create and Open a Runspace
                string fileName = @"D:\script.ps1";
                RunspaceConfiguration config = RunspaceConfiguration.Create();
                Runspace myRs = RunspaceFactory.CreateRunspace(config);
                myRs.Open();
    
                // Attempt to configure PowerShell so we can forcefully run a script.
                RunspaceInvoke scriptInvoker = new RunspaceInvoke(myRs);
                scriptInvoker.Invoke("Set-ExecutionPolicy Unrestricted -Scope Process -Force");
    
                Pipeline pipeline = myRs.CreatePipeline();
                pipeline.Commands.AddScript(fileName);
    
                Collection<PSObject> results = null;
                try
                {
                    results = pipeline.Invoke();
    
                    // Read standard output from the PowerShell script here...
                    foreach (var item in results)
                    {
                        Debug.WriteLine("Normal Output: " + item.ToString());
                    }
                }
                catch (System.Management.Automation.RuntimeException e)
                {
                    Debug.WriteLine("PowerShell Script 'Stop' Error: " + e.Message);
                }
    
                myRs.Close();
            }
        }
    }
