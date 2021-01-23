    using System.Diagnostics;
    namespace ReadEventLogs
    {
      class Program
      {
         public static void Main(string[] args)
         {
            System.Diagnostics.EventLog eventLog1 = new System.Diagnostics.EventLog("Security", ".");
            foreach(EventLogEntry entry in eventLog1.Entries)
            {
              //Event ID 4624 LOGON
              //EVent ID 4634 LOGOFF
              if (entry.InstanceId == 4634)
              {
                Console.WriteLine(entry.Message);
              }
            }
          }
       }
    }
