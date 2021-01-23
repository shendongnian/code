    ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
    procStartInfo.RedirectStandardOutput = true;
    procStartInfo.UseShellExecute = false;
    procStartInfo.CreateNoWindow = true;
    // wrap IDisposable into using (in order to release hProcess) 
    using(Process process = new Process()) {
      process.StartInfo = procStartInfo;
      process.Start();
      // Add this: wait until process does its work
      process.WaitForExit();
      string result = process.StandardOutput.ReadToEnd();
      Console.WriteLine(result);
    }
