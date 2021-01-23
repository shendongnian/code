    string dcrawPath = "dcraw.exe";
    ProcessStartInfo startInfo = new ProcessStartInfo();
    string inputImagePath= "input Raw Image Path/";
    string outputImagePath = "output Raw Image Path/";
    startInfo.RedirectStandardError = true;
    startInfo.RedirectStandardOutput = true;
    startInfo.CreateNoWindow = true;
    startInfo.UseShellExecute = false;
    startInfo.FileName = dcrawPath;
    string commandArg1 = string.Format("\"{0}\"", outputImagePath);
    string commandArg2 = string.Format("\"{0}\"", inputImagePath);
    startInfo.Arguments = "-u ";
    startInfo.Arguments += commandArg1;
    startInfo.Arguments += " -e ";
    startInfo.Arguments += commandArg2;
    startInfo.Arguments += " -T";
    using (Process exeProcess = Process.Start(startInfo))
      {
       exeProcess.WaitForExit();
       string stdout = exeProcess.StandardOutput.ReadToEnd();
       string stderr = exeProcess.StandardError.ReadToEnd();
       Console.WriteLine("Exit code : {0}", exeProcess.ExitCode);
      }
