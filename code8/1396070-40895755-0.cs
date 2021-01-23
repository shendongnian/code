    using System.Diagnostics;
    // Set up the log file to be the folder where the program is run from, with the name Trace.log.
    DefaultTraceListener DefListener = (DefaultTraceListener)Trace.Listeners[0];
    DefListener.LogFileName = AppDomain.CurrentDomain.BaseDirectory + "Trace.log";
    // Write out the value of Count within the loop to the log file.
    for (int Loop = 0; Loop < 5; Loop++)
    {
       Count++;
       Trace.WriteLine($"Count = {Count}");
    }
    DefListener.Flush();
