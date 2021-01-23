    public Dictionary<string, string> memoryStrings
             {
                 get;
                 private set;
             }
    
            public MemoryUsageFragment() {
                memoryStrings = new Dictionary<string, string>();
            }
    
            public override void Capture()
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    memoryStrings.Add("privateMem", string.Format("{0:N0} K", p.PrivateMemorySize64 / 1024));
                    memoryStrings.Add("peakVm", string.Format("{0:N0} K", p.PeakVirtualMemorySize64 / 1024));
                    memoryStrings.Add("peakPaged", string.Format("{0:N0} K", p.PeakPagedMemorySize64 / 1024));
                    memoryStrings.Add("pagedSysMem", string.Format("{0:N0} K", p.PagedSystemMemorySize64 / 1024));
                    memoryStrings.Add("pagedMem", string.Format("{0:N0} K", p.PagedMemorySize64 / 1024));
                    memoryStrings.Add("nonpagedSysMem", string.Format("{0:N0} K", p.NonpagedSystemMemorySize64 / 1024));
                }    
            }
