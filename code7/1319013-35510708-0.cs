    public class DataService
    {
      private DataService(Location location)
      {
        //
      }
      public static DataService At(Location location)
      {
        var result = new DataService(location);
        return result;
      }
      public Order GetOrderDetails(int orderId)
      {
      }
    }
