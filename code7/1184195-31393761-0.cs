    public static class StatusReportManager
    {
       // Standard singleton code to create the manager and access it.
       // Start/create the dispatch time as well.
       
       private static DispatcherTimer Timer { get; set; } 
    
       private static object _syncObject = new object();
    
       public static void ReportStatus(...) 
       {
          lock (_syncObject)
          {
             // Process any states and set instance properties for reading
             // by the timer operation.    
          }        
       }
       private void ShowStatus() // Used by the dispatch timer
       {
            lock (_syncObject)
            {
               // Do any updates to the GUI in here from current state.
            }
       }
    }
