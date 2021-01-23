    Add-Type -TypeDefinition @‘
        using System;
        using System.Globalization;
        using System.Management.Automation;
        using System.Management.Automation.Host;
        public class NotDefaultHost : PSHost {
            private Guid instanceId = Guid.NewGuid();
            private PSObject privateData = new PSObject();
            public override CultureInfo CurrentCulture {
                get {
                    return CultureInfo.CurrentCulture;
                }
            }
            public override CultureInfo CurrentUICulture {
                get {
                    return CultureInfo.CurrentUICulture;
                }
            }
            public override Guid InstanceId {
                get {
                    return instanceId;
                }
            }
            public override string Name {
                get {
                    return "NonDefaultHost";
                }
            }
            public override PSObject PrivateData {
                get {
                    return privateData;
                }
            }
            public override PSHostUserInterface UI {
                get {
                    return null;
                }
            }
            public override Version Version {
                get {
                    return new Version(1, 0);
                }
            }
            public override void EnterNestedPrompt() {
                throw new NotSupportedException();
            }
            public override void ExitNestedPrompt() {
                throw new NotSupportedException();
            }
            public override void NotifyBeginApplication() { }
            public override void NotifyEndApplication() { }
            public override void SetShouldExit(int exitCode) { }
        }
    ’@
    
    $Runspace = [RunspaceFactory]::CreateRunspace((New-Object NotDefaultHost));
    $Runspace.Open()
    $PS=[PowerShell]::Create()
    $PS.Runspace = $Runspace;
    $PS.AddScript('Show-Command -Name Get-Content -PassThru').Invoke()
    if($PS.HadErrors) {
        '--- Errors: ---'
        $PS.Streams.Error
    }
    $PS.Dispose()
    $Runspace.Dispose()
