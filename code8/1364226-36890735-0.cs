    public async Task InvokeAsync()
    {
        var cpuEngine = new CpuEngine(1500);
        var memoryEngine = new MemoryEngine(1500);
        await Task.WhenAll(
            Task.Run(() => cpuEngine.StartCpuCheck()),
            Task.Run(() => memoryEngine.StartCheckMemory()));        
    }
