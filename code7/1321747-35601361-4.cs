      public class MyController : Controller, IDisposable { // note IDisposable
        // no static
        readonly IDbConnection sqlConn = new OracleConnection(...);
        
        public ActionResult Index() {
          // No using  
          sqlConn.Open();
          ...
        }
    
        protected void Dispose(Boolean disposing) {
          if (disposing) {
            sqlConn.Dispose();
          } 
        }
    
        public Dispose() {
          Dispose(true);
    
          GC.SuppressFinalize(this);
        }
      }
