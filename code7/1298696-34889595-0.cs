        try
        {
    	    foreach (Process proc in Process.GetProcessesByName("chromedriver.exe"))
            {
                proc.Kill();
            }
        }
        catch(Exception ex)
        {
    	    MessageBox.Show(ex.Message);
        }
