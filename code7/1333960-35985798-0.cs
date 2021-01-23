    public class StatusReport
    {
        public boolean Ok { get; set; }
        public MyObject Instance { get; set; }
    }
    public static async Task<StatusReport> getObject()
    {
      if (NotOkForSomeReason())
      {
        return new StatusReport { Ok = false };
      }
      return new StatusReport { Ok = true, Instance = await myDataBase.FindAsync(something) };
    }
     
