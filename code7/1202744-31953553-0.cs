    PrintQueue pq = GetYourPrintQueue();
    PrintCapabilities pc = pq.GetPrintCapabilities();
    ReadOnlyCollection<PageMediaSize> capableSizes = pc.PageMediaSizeCapability;
    foreach(var pm in capableSizes) 
    { 
        Console.WriteLine(pm);
    }
    //Identify what PageMediaSize you need, and set your print ticket to use the exact same dimensions
