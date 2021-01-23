    public class MyController : Controller
    {
        //static readonly IDbConnection sqlConn = new OracleConnection(ConfigurationManager.ConnectionStrings["LogDbContext"].ConnectionString);
        readonly string selectLog = "select * from LOG";
        readonly string insertLog = "insert into LOG (ID, Address) values (:ID, :Address)";
    
        // GET: Log
        public ActionResult Index()
        {
            using (sqlConn = new OracleConnection(ConfigurationManager.ConnectionStrings["LogDbContext"].ConnectionString)
            {
                sqlConn.Open();
    
                //IEnumerable log = sqlConn.Query(selectLog);
    
                IEnumerable<Log> log = sqlConn.Query<Log>(selectLog);
    
                foreach (var item in log)
                {
                    Console.WriteLine(item.ToString());
                }
    
            }
    
            return View();
        }
    
        public ActionResult Create()
        {
            using (sqlConn = new OracleConnection(ConfigurationManager.ConnectionStrings["LogDbContext"].ConnectionString)
            {
                sqlConn.Open();
    
                var log = new Log()
                {
                    ID = 1,
                    Address = "test"
                };
    
                sqlConn.Execute(insertLog, log);
    
            }
    
            return View();
        }
    }
