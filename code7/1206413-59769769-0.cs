    using System;
    using System.Management.Automation;
    using Microsoft.PowerShell.Commands;
    using System.Collections.ObjectModel;
    
    namespace PowerJson
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create the Powershell instance, and adds command to be executed
                PowerShell ps = PowerShell.Create();
                ps.AddCommand("Get-Process");
                Collection<PSObject> _ps_results = ps.Invoke();
    
                // Create a JSON Context Object
                JsonObject.ConvertToJsonContext _json_context = new JsonObject.ConvertToJsonContext(maxDepth: 12, enumsAsStrings: false, compressOutput: false);
    
                // Converts the PSObject into JSON
                string json_result = JsonObject.ConvertToJson(_ps_results, _json_context);
    
                // Outputs the result to console
                Console.WriteLine(json_result);
            }
        }
    }
 
