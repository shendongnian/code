    Add-Type -TypeDefinition @‘
        using System;
        using System.Management.Automation;
        [Cmdlet(VerbsLifecycle.Invoke, "Command1")]
        public class Command1 : Cmdlet {
            protected override void ProcessRecord() {
                WriteObject("Command 1");
            }
        }
        public class ModuleInitializer : IModuleAssemblyInitializer {
            public void OnImport() {
                using(PowerShell ps = PowerShell.Create(RunspaceMode.CurrentRunspace)) {
                    ps.AddCommand("Write-Host").AddArgument("Before submodule import").AddStatement().
                       AddCommand("Import-Module").AddArgument(".\\Assembly2.dll").AddStatement().
                       AddCommand("Write-Host").AddArgument("After submodule import").Invoke();
                }
            }
        }
    ’@ -OutputAssembly .\Assembly1.dll
    Add-Type -TypeDefinition @‘
        using System;
        using System.Management.Automation;
        [Cmdlet(VerbsLifecycle.Invoke, "Command2")]
        public class Command2 : Cmdlet {
            protected override void ProcessRecord() {
                WriteObject("Command 2");
            }
        }
        public class ModuleInitializer : IModuleAssemblyInitializer {
            public void OnImport() {
                using(PowerShell ps = PowerShell.Create(RunspaceMode.CurrentRunspace)) {
                    ps.AddCommand("Write-Host").AddArgument("Importing submodule").Invoke();
                }
            }
        }
    ’@ -OutputAssembly .\Assembly2.dll
    Write-Host 'Before module import'
    Import-Module .\Assembly1.dll
    Write-Host 'After module import'
    Invoke-Command2
