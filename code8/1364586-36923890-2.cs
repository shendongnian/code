        [DllImport("psapi.dll")]
		static extern int EmptyWorkingSet(IntPtr hwProc);
		
		static void MinimizeFootprint()
		{
            EmptyWorkingSet(System.Diagnostics.Process.GetCurrentProcess().Handle);
		}
        ... 
        
	    GC.Collect();
		MinimizeFootprint();
