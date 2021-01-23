    ... 
    using System.Printing;
    ...
    var ps = new PrintServer();
    var queues = ps.GetPrintQueues(
    new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
    var bool Is200dpi = false;
    var bool Is300dpi = false;
    var int  ActualDPI = 203; // just some default    
    foreach (var queue in queues)
    {
       if (queue.Name.Trim().Equals( "ThePrinterOnYourMachine" ))
       {
          var pt = queue.DefaultPrintTicket;
          if (pt.PageResolution.X >= 200 && pt.PageResolution.X <= 203)
             Is200dpi = true;
          else if (pt.PageResolution.X >= 300 && pt.PageResolution.X <= 303)
             Is300dpi = true;
          ActualDPI = pt.PageResolution.X;
    
          // done, don't need to look at any other printers
          break;
       }
    }
