    private IReadOnlyDictionary<string, string> _memoryStrings;
    public IReadOnlyDictionary<string, string> memoryStrings
    {
    	get
    	{
    		return _memoryStrings;
    	}
    	private set
    	{
    		if (_memoryStrings != null && _memoryStrings.Count() > 0) return;
    		_memoryStrings = value;
    	}
    }
    
    public void Capture()
    {
    	if (memoryStrings == null || memoryStrings.Count() == 0)
    	{
    		using (Process p = Process.GetCurrentProcess())
    		{
    			memoryStrings = new Dictionary<string, string>
    			{
    				{"privateMem", string.Format("{0:N0} K", p.PrivateMemorySize64 / 1024)},
    				{"peakVm", string.Format("{0:N0} K", p.PeakVirtualMemorySize64 / 1024)},
    				{"peakPaged", string.Format("{0:N0} K", p.PeakPagedMemorySize64 / 1024)},
    				{"pagedSysMem", string.Format("{0:N0} K", p.PagedSystemMemorySize64 / 1024)},
    				{"pagedMem", string.Format("{0:N0} K", p.PagedMemorySize64 / 1024)},
    				{ "nonpagedSysMem", string.Format("{0:N0} K", p.NonpagedSystemMemorySize64 / 1024)}
    			};
    		}
    	}
    }
