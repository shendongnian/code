        Process[] pname = Process.GetProcessesByName("iexplore");
        if (pname.Length == 0)
        {
           Process.Start("IEXPLORE.EXE", "http://www.somesite.com/subscriber/");        
        }
        else
        {
           try
           {
                foreach (Process proc in Process.GetProcessesByName("iexplore"))
                {
                    proc.Kill();
                }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }
