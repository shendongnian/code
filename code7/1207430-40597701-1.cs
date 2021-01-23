    public static long GetProcessPrivateWorkingSet64Size(int process_id)
    {
      long process_size = 0;
      Process process = Process.GetProcessById(process_id);
      if (process == null) return process_size;
      string instanceName = GetProcessInstanceName(process.Id);
      var counter = new PerformanceCounter("Process", "Working Set - Private", instanceName, true);
      process_size = Convert.ToInt32(counter.NextValue()) / 1024;
      return process_size;
    }
    public static string GetProcessInstanceName(int process_id)
    {
      PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
      string[] instances = cat.GetInstanceNames();
      foreach (string instance in instances)
      {
        using (PerformanceCounter cnt = new PerformanceCounter("Process", "ID Process", instance, true))
        {
           int val = (int)cnt.RawValue;
           if (val == process_id)
             return instance;
        }
      }
      throw new Exception("Could not find performance counter ");
    }
