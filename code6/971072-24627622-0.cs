    const string file = "test.log";
    // Adds new line.
    AutoResetEvent signal = new AutoResetEvent(false);
        
    streamWriter.Flush();
    // Adds new line.
    signal.Set();
    File.Delete(file);
    // Adds new line
    signal.Set();
    
    Thread.Sleep(500);
    // Replaces with.
    signal.WaitOne();
    
    while ((line = streamReader.ReadLine()) != null) Console.WriteLine(line);
    // Replaces with.
    while ((line = streamReader.ReadLine()) != null)
    {
        signal.WaitOne();
        Console.WriteLine(line);
    }
