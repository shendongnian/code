    using System.Globalization;
    using System.Diagnostics.Eventing.Reader;
    EventLogQuery filter = new EventLogQuery("Application", PathType.LogName, "Event[System[Level=2 and (EventID = 1000 or EventID = 1002)] and EventData[Data[1] = \"example.exe\"]]")
    EventLogWatcher watcher = new EventLogWatcher(filter);
    watcher.EventRecordWritten += Watcher_ApplicationError; // Register our handler
    watcher.Enabled = true; // Start delivering events to the handler
    private void Watcher_ApplicationError(object sender, EventRecordWrittenEventArgs e) 
    {
         String rawId = e.EventRecord.Properties[8].Value.ToString(); // Faulting process id
         
         Int32 id = -1;
         if (!Int32.TryParse(rawId, out id)) // If not integer, possibly hexadecimal
         {
             if (!Int32.TryParse(rawId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out id)
                 return; // Unable to read the process id successfully
         }
         Process unresponsive = Process.GetProcessById(id); // Get the unresponsive process
         unresponsive.Kill(); // Kill it
    }
