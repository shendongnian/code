    namespace EF.XML
    {
    using System;
    using System.Linq;
    using System.Management.Automation;
    [Cmdlet(VerbsCommon.Get, "DemoNames")]
    public class Get_DemoNames : PSCmdlet
    {
    [Parameter(Position = 0, Mandatory = false)]
    public string prefix;
    protected override void ProcessRecord()
    {
        var names = new[] { "Chris", "Charlie", "Isaac", "Simon" };
        if (string.IsNullOrEmpty(prefix))
        {
            WriteObject(names, true);
        }
        else
        {
            var prefixed_names = names.Select(n => prefix + n);
            WriteObject(prefixed_names, true);
        }
        //added
        const string networkPath = "Microsoft.PowerShell.Core\\FileSystem::";
        var currentPath = SessionState.Path.CurrentFileSystemLocation.Path;
        var curProjectDir = currentPath.Substring(networkPath.Length); 
        WriteObject(curProjectDir);
        System.Diagnostics.Debug.Write("hello");
        var parser = new Parser {CurrentProjectDirectory = curProjectDir };
        parser.UpdateXml();
        }
    
      }
    }
