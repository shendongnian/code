    var printServer = new PrintServer();
    var myPrintQueues = printServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
    foreach (PrintQueue pq in myPrintQueues)
    {
        pq.Refresh();
        if (!pq.Name.ToLower().Contains("es5461")) continue;  
        PrintJobInfoCollection jobs = pq.GetPrintJobInfoCollection();
        foreach (PrintSystemJobInfo job in jobs)
        {
            var aux = job;
        }// end for each print job    
    }// end for each print queue
