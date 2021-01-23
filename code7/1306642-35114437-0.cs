    using System;
    using System.Management.Automation;
    namespace MyPowerShellApp {
        public class User {
            public static string StaticHello() {
                return "Hello from the static method!";
            }
            public string InstanceHello() {
                return "Hello from the instance method!";
            }
        }
        class Program {
            static void Main(string[] args) {
                using (PowerShell ps = PowerShell.Create()) {
                    ps.AddScript("[MyPowerShellApp.User]::StaticHello();(New-Object MyPowerShellApp.User).InstanceHello()");
                    foreach (PSObject result in ps.Invoke()) {
                        Console.WriteLine(result);
                    }
                }
                Console.WriteLine("Press any key for exit...");
                Console.ReadKey();
            }
        }
    }
