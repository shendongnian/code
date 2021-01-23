    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + tasklist /s <RemoteMachineName>/u <username>/p <password>);
            Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
           procStartInfo.UseShellExecute = false;
           procStartInfo.CreateNoWindow = true;
     System.Diagnostics.Process proc = new System.Diagnostics.Process();
          proc.StartInfo = procStartInfo;
          proc.Start();
