    using System.Timers;
    public class MyTimedDelete {
      private static List<int> ListOfIds=null;
      private static System.Timers.Timer myTimer=null;
      public static void AddIdToQueue(int id)
      {
          if (ListOfIds == null)
          {
             ListOfIds = new List<int>();
             myTimer = new System.Timers.Timer(2000);
             myTimer.Elapsed += OnTimedEvent;
          }
          ListOfIds.Add(id);
          if (ListOfIds.Count==1)
          {
              myTimer.Start();
          }    
      }
      private static void OnTimedEvent(Object source, ElapsedEventArgs e)
      {
          deleteItem(ListOfIds[0]);
          ListOfIds.RemoveAt(0);
          if (ListOfIds.Count == 0) {
              myTimer.Stop();
          }
      }
    }
