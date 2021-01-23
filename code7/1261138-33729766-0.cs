    using System.Diagnostics;
     ProcessStartInfo processInfo = new ProcessStartInfo();
     processInfo.Arguments = "Some argument";
     processInfo.FileName = "Your console .exe path"; 
     int exitCode;
     using (Process process = Process.Start(processInfo))
     {
                process.WaitForExit();
                exitCode = process.ExitCode;
     }
