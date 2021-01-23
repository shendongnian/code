    public class SingleProc
    {
      private static SingleProc instance;
      private SingleProc() { }
      public Process Proc { get; set; }
      public static void RunTillExit()
      {
        Instance.Proc.Start();
        Instance.Proc.WaitForExit();
      }
      public static SingleProc Instance
      {
        get
        {
          if (instance == null)
          {
            instance = new SingleProc();
          }
          return instance;
        }
      }
    }
