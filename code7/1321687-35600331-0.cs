    using System;
    using System.Diagnostics;
    using System.Management;
    namespace Test
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                var queryString =
                    "SELECT TargetInstance " +
                    "FROM __InstanceCreationEvent WITHIN 1 " +
                    "WHERE TargetInstance ISA 'Win32_Process' " +
                    "AND TargetInstance.Name LIKE 'notepad.exe'";
                var scope = @"\\.\root\CIMV2";
                var watcher = new ManagementEventWatcher(scope, queryString);
                watcher.EventArrived += watcher_EventArrived;
                watcher.Start();
                Process.Start("notepad.exe");
                Console.ReadKey();
            }
            static void watcher_EventArrived(object sender, EventArrivedEventArgs e)
            {
                Console.WriteLine("Notepad has been started");
            }
        }
    }
