    public void MonitorPrintJobs()
    {
        string queryClassName = "__InstanceOperationEvent";
        string queryCond = "TargetInstance ISA 'Win32_PrintJob'";
        TimeSpan queryTimeSpan = new TimeSpan(1);
        try
        {
            WqlEventQuery eventQuery = new WqlEventQuery(queryClassName, queryTimeSpan, queryCond);
            ManagementEventWatcher watcher = new ManagementEventWatcher(eventQuery);
            if (PrintJobChange != null)
            {
                watcher.EventArrived += PrintJobChange;
            }
                
            watcher.Start();
        }
        catch (Exception ex)
        {
            string msg = string.Format("Error monitoring print jobs. Exception {0} Trace {1}.",
            ex.Message, ex.StackTrace);
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
