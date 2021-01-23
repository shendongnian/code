      public class MyController : Controller {
        static readonly IDbConnection sqlConn = new OracleConnection(...);
    
        public ActionResult Index() {
          // No using  
          sqlConn.Open();
          ...
        }
    
        private static void OnExit(Object sender, EventArgs e) {
          sqlConn.Dispose();
        }
    
        static MyController() {
          Application.ApplicationExit += OnExit;
        }
      }
