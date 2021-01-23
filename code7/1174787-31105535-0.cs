    private void Kill_IE()
    {
        Process[] ps = Process.GetProcessesByName("IEXPLORE");
    
        foreach (Process p in ps)
        {
            try
            {
                if (!p.HasExited)
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Unable to kill process {0}, exception: {1}", p.ToString(), ex.ToString()));
            }
        }
    }
