     ProcessStartInfo startInfo = new ProcessStartInfo();
     startInfo.CreateNoWindow = false;
     startInfo.UseShellExecute = false;
     startInfo.FileName = "abc.exe";
     startInfo.WindowStyle = ProcessWindowStyle.Hidden;
     startInfo.Arguments = args;
    
     try
     {
         Process exeProcess = Process.Start(startInfo);
         exeProcess.EnableRaisingEvents = true;
         exeProcess.Exited +=  OnProcessExited;
     }
     catch (Exception ex)
     {
         // Log error.
         Console.WriteLine(ex.Message);
     }   
     private static void OnProcessExited(object sender, EventArgs eventArgs)
     {
         // do your work here   
     }
