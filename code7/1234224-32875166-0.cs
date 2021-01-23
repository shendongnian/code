        static void Main(string[] args)
        {
            string pol = "2";
            string appName = "Notepad.exe";
            string queryString =
                "SELECT *" +
                "  FROM __InstanceOperationEvent " +
                "WITHIN  " + pol +
                " WHERE TargetInstance ISA 'Win32_Process' " +
                "   AND TargetInstance.Name = '" + appName + "'";
            // You could replace the dot by a machine name to watch to that machine
            string scope = @"\\.\root\CIMV2";
            // create the watcher and start to listen
            ManagementEventWatcher watcher = new ManagementEventWatcher(scope, queryString);
            watcher.EventArrived += new EventArrivedEventHandler(OnEventArrived);
            watcher.Start();
            Console.Read();
        }
        private static void OnEventArrived(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.ClassPath.ClassName.Contains("InstanceCreationEvent"))
                Console.WriteLine("Notepad started");
            else if (e.NewEvent.ClassPath.ClassName.Contains("InstanceDeletionEvent"))
                Console.WriteLine("Notepad Exited");
            else
                Console.WriteLine(e.NewEvent.ClassPath.ClassName);
        }
