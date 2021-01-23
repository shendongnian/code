    private void Form1_Load(object sender, EventArgs e)
    {
    	progressBar1.Maximum = 10000;
    	progressBar1.Minimum = 0;
    	bkwCpuLoad.RunWorkerAsync();
    }
    private void bkwCpuLoad_DoWork(object sender, DoWorkEventArgs e)
    {
    	ulong i;
    	i = 0;
    	try
    	{
    		ManagementClass cpuDataClass = new ManagementClass("Win32_PerfFormattedData_PerfOS_Processor");
    
    		while (true)
    		{
    			ManagementObjectCollection cpuDataClassCollection = cpuDataClass.GetInstances();
    			foreach (ManagementObject obj in cpuDataClassCollection)
    			{
    				if (obj["Name"].ToString() == "_Total")
    				{
    					i = Convert.ToUInt64(obj["C1TransitionsPersec"]);
    				}
    				bkwCpuLoad.ReportProgress((int)i);
    			}
    			Thread.Sleep(100);
    		}
    	}
    	catch (ThreadAbortException tbe)
    	{
    
    	}
    }
    private void bkwCpuLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	var perc = e.ProgressPercentage;
    	if (perc > progressBar1.Maximum)
    		perc = progressBar1.Maximum;
    	progressBar1.Value = perc;
    	try
    	{
    		progressBar1.Value--;
    		progressBar1.Value++;
    	}
    	catch
    	{
    	}
    }
