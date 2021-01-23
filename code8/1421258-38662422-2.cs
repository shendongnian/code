    var process = new Process()
    {
           StartInfo = new System.Diagnostics.ProcessStartInfo()
           {
               FileName = "[your file]"
           }
    };
    if (!process.Start())
    {
          // Handle the case where it didn't start
    }
