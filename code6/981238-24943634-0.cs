    public class ProcessInfo
    {
       public string Name { get; set; }
       public int PID { get; set; }
       public int CPU { get; set; }
       public int Thd { get; set; }
       public int Hnd { get; set; }
       public TimeSpan CpuTime { get; set; }
       public TimeSpan ElapsedTime { get; set; }
    }
