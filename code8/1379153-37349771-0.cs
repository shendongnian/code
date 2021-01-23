     string output;
    
     // wrap IDisposable into using
     using (var process = new Process()) {
            process.StartInfo.WorkingDirectory = directoryWhereKix32Is;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = @"directoryWhereKix32Is\KIX32.EXE";
            process.StartInfo.Arguments = "myKix";
            process.Start();
    
            // First wait for exit; give KIX32.EXE a chance to execute the script
            process.WaitForExit();
            // Only then (when execution compteted) read into output    
            output = process.StandardOutput.ReadToEnd();
      } 
