    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    
    namespace GetWMI_Info
    {
        public class EventWatcherAsync
        {
            private void WmiEventHandler(object sender, EventArrivedEventArgs e)
            {
                Console.WriteLine("TargetInstance.Name :       " + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Name"]);
    
            }
    
            public EventWatcherAsync()
            {
                try
                {
                    string ComputerName = "localhost";
                    string WmiQuery;
                    ManagementEventWatcher Watcher;
                    ManagementScope Scope;
    
    
                    if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                    {
                        ConnectionOptions Conn = new ConnectionOptions();
                        Conn.Username = "";
                        Conn.Password = "";
                        Conn.Authority = "ntlmdomain:DOMAIN";
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), Conn);
                    }
                    else
                        Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
                    Scope.Connect();
    
                    WmiQuery = "Select * From __InstanceModificationEvent Within 1 " +
                    "Where TargetInstance ISA 'Win32_Printer' ";
    
                    Watcher = new ManagementEventWatcher(Scope, new EventQuery(WmiQuery));
                    Watcher.EventArrived += new EventArrivedEventHandler(this.WmiEventHandler);
                    Watcher.Start();
                    Console.Read();
                    Watcher.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception {0} Trace {1}", e.Message, e.StackTrace);
                }
    
            }
    
            public static void Main(string[] args)
            {
                Console.WriteLine("Listening {0}", "__InstanceModificationEvent");
                Console.WriteLine("Press Enter to exit");
                EventWatcherAsync eventWatcher = new EventWatcherAsync();
                Console.Read();
            }
        }
    }
