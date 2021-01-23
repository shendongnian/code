    using System.Linq;
    using System.Management.Automation;
    namespace MyModule.Commands
    {
        [Cmdlet(VerbsLifecycle.Invoke, "AnotherCmdlet")]
        public class InvokeAnotherCmdlet : Cmdlet
        {
            [Parameter(Mandatory = true)]
            public string Username { get; set; }
            protected override void ProcessRecord()
            {
                GetADUserCommand anotherCmdlet = new GetADUserCommand() {
                    // Pass CommandRuntime of calling cmdlet to the called cmdlet (note 1)
                    CommandRuntime = this.CommandRuntime, 
                    // Set parameters
                    Username = this.Username
                };
                // Cmdlet code isn't ran until the resulting IEnumerable is enumerated (note 2)
                anotherCmdlet.Invoke<object>().ToArray();
            }
        }
        [Cmdlet(VerbsCommon.Get, "ADUser")]
        public class GetADUserCommand : Cmdlet
        {
            [Parameter(Mandatory = true)]
            public string Username { get; set; }
            protected override void ProcessRecord()
            {
                WriteVerbose($"Getting AD User '{Username}'");
            }
        }
    }
