    foreach (string command in commands) {
             while (waitforcoversion == 4) {
                  System.Threading.Thread.Sleep(1000);
             }
             waitforcoversion++;
             trans_aac(command);
    }
    while (waitforcoversion != 0) {//To make sure every conversion is complete
           System.Threading.Thread.Sleep(1000);
    }
    MessageBox.Show("conversion complete");
    static void trans_aac(string command) {
    
      Process proc = new Process();
      proc.StartInfo.FileName = "cmd.exe";
      proc.StartInfo.Arguments = command;
      proc.EnableRaisingEvents = true;
      proc.Exited += ProcessExited;
      proc.StartInfo.CreateNoWindow = true;
      proc.Start();
    }
    static void ProcessExited(object sender, EventArgs e) {
        waitforcoversion--;
    }
