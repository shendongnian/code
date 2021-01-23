     System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(sProcessName);
      if (proc.Length > 0)
      {
          MessageBox.Show(String.Format("{0}is  running!", sProcessName), sProcessName);
      }
      else
      {
          MessageBox.Show(String.Format("{0}is not running!", sProcessName), sProcessName);
         
       }
