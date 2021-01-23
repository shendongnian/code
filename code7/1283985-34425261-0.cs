    interface IBarDataHandler
    {
      string GetUserToken(int id);
    }
    public class BarDataHandler : IBarDataHandler
    {
      public string GetUserToken(int id)
      {
         // to do :read from db and return
      }
    }
