      int exitCode = -1;
      // Put IDisposable into using
      using (var proc = new Process()) {
        proc.StartInfo.FileName = "thefile.exe";
        proc.StartInfo.RedirectStandardInput = true;
        proc.Start();
        using (StreamWriter inputWriter = proc.StandardInput) {
          inputWriter.Write('\n');
        }
        proc.WaitForExit();
        exitCode = proc.ExitCode;
      }
