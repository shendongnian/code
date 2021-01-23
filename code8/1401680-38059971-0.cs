    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Management.Automation;
    namespace ConsoleTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string cmdLetName = "Get-Content";
                Collection<PSObject> PSOutput;
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddCommand("Get-Command");
                    PowerShellInstance.AddParameter("Name", cmdLetName);
                    PSOutput = PowerShellInstance.Invoke();
                }
    
                foreach(var item in PSOutput)
                {
                    var cmdLetInfo = item.BaseObject as System.Management.Automation.CmdletInfo;
                    var defaultParamSet = cmdLetInfo.ParameterSets.Where(pSet => pSet.IsDefault == true).FirstOrDefault();
    
                    Console.WriteLine(String.Format("Default ParameterSet for {0}.  (*) Denotes Mandatory", cmdLetName));
                    foreach (var param in defaultParamSet.Parameters.OrderByDescending(p => p.IsMandatory))
                    {
                        if (param.IsMandatory)
                            Console.WriteLine(String.Format("\t {0} (*)", param.Name));
                        else
                            Console.WriteLine(String.Format("\t {0}", param.Name)); ;
                    }
                }
    
                Console.ReadLine();
            }
        }
    }
