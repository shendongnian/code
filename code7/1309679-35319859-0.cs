    public interface ITimeSpanTest
    {
      TimeSpan Timeout { get; }
      TimeSpan LogTimeout { get; set; }
    }
    
    public class TimeSpanTest : ITimeSpanTest
    {
      public TimeSpan LogTimeout { get; set; }
      public TimeSpan Timeout { get; }
    
      public string Process { get; set; }
    
      public TimeSpanTest(TimeSpan logTimeout, string process)
      {
        this.Timeout = TimeSpan.FromSeconds(1);
        this.LogTimeout = logTimeout;
        this.Process = process;
      }
    }
