    public void runProcess(string aPath,string aName,string aFiletype)
    {
    
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("Started: {0}",DateTime.Now.ToString("dd-MMM hh:mm:ss"));
      Console.WriteLine("Will try run this file {0} {1}",aPath,aName);
      Console.WriteLine("File type {0}",aFiletype);
    
      string stInfoFileName;
      string stInfoArgs;
    
      if(aFiletype == "bat")
      {
        //changed these 2 lines>>>
        //stInfoFileName = @"cmd.exe";
        //stInfoArgs = "//c " + aName;
          stInfoFileName = (@aPath + @aName);
          stInfoArgs = string.Empty;
        /////////
      }
      else
      { //vbs
        stInfoFileName = @"cscript";
        stInfoArgs = "//B " + aName;
      }
    
      this.aProcess.StartInfo.FileName = stInfoFileName;
      this.aProcess.StartInfo.Arguments =  stInfoArgs;
      this.aProcess.StartInfo.WorkingDirectory = @aPath;
      this.aProcess.StartInfo.CreateNoWindow = true;
      this.aProcess.StartInfo.UseShellExecute = false;
      this.aProcess.StartInfo.RedirectStandardError = true;
      this.aProcess.StartInfo.RedirectStandardOutput = true;
    
      this.aProcess.Start();
      Console.WriteLine("<<<got to here");
      
      /////////
      //following Luaan's advice I replaced the following with the below
      //Console.WriteLine(this.aProcess.StandardOutput.ReadToEnd());
      //Console.WriteLine(this.aProcess.StandardError.ReadToEnd());
        aProcess.ErrorDataReceived += (s,e) => Console.WriteLine(e.Data);
        aProcess.OutputDataReceived += (s,e) => Console.WriteLine(e.Data);
        aProcess.BeginOutputReadLine();
        aProcess.BeginErrorReadLine();
      /////////
    
      this.aProcess.WaitForExit(); //<-- Optional if you want program running until your script exit
      this.aProcess.Close();
    
      Console.WriteLine("Finished: {0}",DateTime.Now.ToString("dd-MMM hh:mm:ss"));
    }
