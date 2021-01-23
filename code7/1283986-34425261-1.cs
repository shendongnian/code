    public class FooBusiness
    {
      IBarDataHandler barDataHandler;
      public FooBusiness(IBarDataHandler barDataHandler)
      {
        this.barDataHandler=barDataHandler
      }
      public string GetUserToken(int id)
      {
        return this.barDataHandler.GetUserToken(id);
      }
    }
