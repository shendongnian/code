        Process[] pname = Process.GetProcessesByName("IEXPLORE.EXE");
        if (pname.Length == 0)
        {
           Process.Start("IEXPLORE.EXE", "http://www.somesite.com/subscriber/");        
        }
        else
        {
           try
           {
                foreach (Process proc in Process.GetProcessesByName("IEXPLORE.EXE"))
                {
                    proc.Kill();
                }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }
