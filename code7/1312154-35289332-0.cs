    // Declare the counter somewhere
    var process_cpu = new PerformanceCounter(
                                       "Process", 
                                       "% Processor Time", 
                                       Process.GetCurrentProcess().ProcessName
                                            );
    // Read periodically
    var processUsage = process_cpu.NextValue() / Environment.ProcessorCount;
