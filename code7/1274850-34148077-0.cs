    private static readonly object o = new object();
    public static string GenerateNextCustomerId() {
       lock (o) {
          // Write code to get the next counter from db in this method
           var counter = GetNextCounter();
           var nextCustomerId = string.Format("{0}{1}{2}",
                                DateTime.Now.Year, DateTime.Now.Month,
                                counter.ToString().PadLeft(4, '0'));
           // Write code to increment the counter and save to db in this method
           IncrementCounter();
           return nextCustomerId;
       }
    }
