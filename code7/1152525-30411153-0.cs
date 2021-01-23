    try
    {
          Process proc = Process.GetProcessesByName("paint");
          proc.Kill();
    }
    catch (Exception ex)
    {
          MessageBox.Show(ex.Message.ToString()); 
    }
