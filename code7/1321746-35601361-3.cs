    public class MyController : Controller {
      // No sqlConn field
      public ActionResult Index() {
        using (IDbConnection sqlConn = new OracleConnection(...)) {
          sqlConn.Open();
          ...
        }
      }
