    public static void PrintGpuProperties() // this was copied from CudafyByExample
    {
        int i = 0;
    
        foreach (GPGPUProperties devicePropsContainer in CudafyHost.GetDeviceProperties(CudafyModes.Target, false))
        {
            Console.WriteLine("   --- General Information for device {0} ---", i);
            Console.WriteLine("Name:  {0}", devicePropsContainer.Name);
            Console.WriteLine("Platform Name:  {0}", devicePropsContainer.PlatformName);
            Console.WriteLine("Device Id:  {0}", devicePropsContainer.DeviceId);
            Console.WriteLine("Compute capability:  {0}.{1}", devicePropsContainer.Capability.Major, devicePropsContainer.Capability.Minor);
            Console.WriteLine("Clock rate: {0}", devicePropsContainer.ClockRate);
            Console.WriteLine("Simulated: {0}", devicePropsContainer.IsSimulated);
            Console.WriteLine();
    
            Console.WriteLine("   --- Memory Information for device {0} ---", i);
            Console.WriteLine("Total global mem:  {0}", devicePropsContainer.TotalMemory);
            Console.WriteLine("Total constant Mem:  {0}", devicePropsContainer.TotalConstantMemory);
            Console.WriteLine("Max mem pitch:  {0}", devicePropsContainer.MemoryPitch);
            Console.WriteLine("Texture Alignment:  {0}", devicePropsContainer.TextureAlignment);
            Console.WriteLine();
    
            Console.WriteLine("   --- MP Information for device {0} ---", i);
            Console.WriteLine("Shared mem per mp: {0}", devicePropsContainer.SharedMemoryPerBlock);
            Console.WriteLine("Registers per mp:  {0}", devicePropsContainer.RegistersPerBlock);
            Console.WriteLine("Threads in warp:  {0}", devicePropsContainer.WarpSize);
            Console.WriteLine("Max threads per block:  {0}", devicePropsContainer.MaxThreadsPerBlock);
            Console.WriteLine("Max thread dimensions:  ({0}, {1}, {2})", devicePropsContainer.MaxThreadsSize.x, devicePropsContainer.MaxThreadsSize.y, devicePropsContainer.MaxThreadsSize.z);
            Console.WriteLine("Max grid dimensions:  ({0}, {1}, {2})", devicePropsContainer.MaxGridSize.x, devicePropsContainer.MaxGridSize.y, devicePropsContainer.MaxGridSize.z);
    
            Console.WriteLine();
    
            i++;
        }
    }
