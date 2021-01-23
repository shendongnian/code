    var process = Process.Start(@"..path to your exe....");       
    //Wait for the DOS exe to start, and create its console window
    while (process.MainWindowHandle == IntPtr.Zero)
    {
      Thread.Sleep(500);
    }
    //Attach to the console of our DOS exe
    if (!AttachConsole(process.Id))
      throw new Exception("Couldn't attach to console");
            
    while (true)
    {
      var strings = ConsoleReader.ReadFromBuffer(0, 0,  
                        (short)Console.BufferWidth, 
                         short)Console.BufferHeight);
      foreach (var str  in strings.
                         Select(s => s?.Trim()).
                         Where(s => !String.IsNullOrEmpty(s)))
     {
        Debug.WriteLine(str);          
     }
     Thread.Sleep(1000);
    }
