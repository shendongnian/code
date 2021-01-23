        private static void mergelhetőVerziókListája()
        {
          string revíziók = cmd("svn", "mergeinfo --show-revs eligible \".../branches/dev\" \".../trunk\"");
        }
    
        private static string cmd(string utasítás, string paraméter)
        {
          StringBuilder eredmény = new StringBuilder();
          Process cmd = new Process()
          {
            StartInfo = new ProcessStartInfo
            {
              FileName = utasítás,
              Arguments = paraméter,
              UseShellExecute = false,
              RedirectStandardOutput = true,
              CreateNoWindow = true
            }
          };
          cmd.Start();
          while (!cmd.StandardOutput.EndOfStream)
          {
            string kimenet = cmd.StandardOutput.ReadLine();
            eredmény.AppendLine(kimenet); //...
          }
          return eredmény.ToString();
        }
