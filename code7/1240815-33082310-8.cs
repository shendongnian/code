    Add-Type -TypeDefinition @‘
        using System;
        using System.Management.Automation;
        [Cmdlet(VerbsDiagnostic.Test, "WriteInformation")]
        public class TestWriteInformationCmdlet : PSCmdlet {
            protected override void ProcessRecord() {
                WriteInformation(new HostInformationMessage { Message="SomeText",
                                                              ForegroundColor=ConsoleColor.Red,
                                                              BackgroundColor=Host.UI.RawUI.BackgroundColor,
                                                              NoNewLine=false
                                                            }, new[] { "PSHOST" });
            }
        }
    ’@ -PassThru|Select-Object -ExpandProperty Assembly|Import-Module
    Test-WriteInformation
