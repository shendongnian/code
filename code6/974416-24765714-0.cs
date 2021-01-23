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
                // e.NewEvent
                string wclass = ((ManagementBaseObject)e.NewEvent).SystemProperties["__Class"].Value.ToString();
                string wop = string.Empty;
                switch (wclass)
                {
                    case "__InstanceModificationEvent":
                        wop = "Modified";
                        break;
                    case "__InstanceCreationEvent":
                        wop = "Created";
                        break;
                    case "__InstanceDeletionEvent":
                        wop = "Deleted";
                        break;
                }
                string wfilename = ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["FileName"].ToString();
    
                if (!string.IsNullOrEmpty(((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Extension"].ToString()))
                {
                    wfilename += "." + ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)["Extension"].ToString();
                }
                Console.WriteLine(String.Format("The File {0} was {1}", wfilename, wop));
    
    
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
                    //Check for changes in the path C:\Test
                    WmiQuery = @"Select * From __InstanceOperationEvent Within 1 
                    Where TargetInstance ISA 'CIM_DataFile' and TargetInstance.Drive = 'C:' AND TargetInstance.Path='\\Test\\'";
    
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
                Console.WriteLine("Listening {0}", "__InstanceOperationEvent");
                Console.WriteLine("Press Enter to exit");
                EventWatcherAsync eventWatcher = new EventWatcherAsync();
                Console.Read();
            }
        }
    }
