    Process p = new Process();
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.RedirectStandardOutput = true;
    p.StartInfo.RedirectStandardInput = true;
    p.StartInfo.RedirectStandardError = true;
    p.StartInfo.CreateNoWindow = true;
    p.StartInfo.FileName = mainCmd;
    p.StartInfo.Arguments = arguments;
    p.Start();
    using (StreamWriter inputWriter = p.StandardInput)
    {
       foreach(string line in commands)
       {
          //Wait before next input in case when empty string passed
          if (string.IsNullOrEmpty(line))
             System.Threading.Thread.Sleep(1000 * 2);
                
          inputWriter.WriteLine(line);
       }
    }
    output = p.StandardOutput.ReadToEnd();
    output += Environment.NewLine;
    output += p.StandardError.ReadToEnd();
    p.WaitForExit(timeout);
