    public void runProcess(string aPath,string aName,string aFiletype)
    {
      aProcess = new Process();
    
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Started: {0}",DateTime.Now.ToString("dd-MMM hh:mm:ss"));
      Console.WriteLine("Will try run this file {0} {1}",aPath,aName);
      Console.WriteLine("File type {0}",aFiletype);
    
      string stInfoFileName;
      string stInfoArgs;
    
      if(aFiletype == "bat")
      {
        stInfoFileName = (@aPath + @aName);
        stInfoArgs = string.Empty;
      }
      else
      { //vbs
        stInfoFileName = @"cscript";
        stInfoArgs = "//B " + aName;
      }
    
      this.aProcess.StartInfo.FileName = stInfoFileName;
      this.aProcess.StartInfo.Arguments =  stInfoArgs;
    
      this.aProcess.StartInfo.WorkingDirectory = @aPath;
    
      //new 18 june 2015//////
      if(aFiletype == "bat")
      {
        this.aProcess.StartInfo.CreateNoWindow = true;
        this.aProcess.StartInfo.UseShellExecute = false;
        this.aProcess.StartInfo.RedirectStandardError = true;     //<< HJ
        this.aProcess.StartInfo.RedirectStandardOutput = true;    //<< HJ
      }
      ////////////////////////
    
      this.aProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal; //.Hidden
      this.aProcess.Start();
    
      aProcessName = this.aProcess.ProcessName;
      if(aFiletype == "bat")
      {
        this.aProcess.ErrorDataReceived += (s,e) => Console.WriteLine(e.Data);
        this.aProcess.OutputDataReceived += (s,e) => Console.WriteLine(e.Data);
        this.aProcess.BeginOutputReadLine();
        this.aProcess.BeginErrorReadLine();
      }
    
      this.aProcess.WaitForExit();
      this.aProcess.Dispose();
    
    Console.WriteLine("Process {0} closed: {1}", this.aProcessName, DateTime.Now.ToString("dd-MMM hh:mm:ss"));
    }
