    using System;
    ...
    
    namespace ...
    {
        public class MyController : Controller
        {   
            public ActionResult Index()
            {
                var myResultsList = new List<MyModel>();
                string connectionString = ConfigurationManager.AppSettings["myDBConn"];
                var conn = new SqlConnection(connectionString);
                conn.Open();
                string query = @"usp_getIds";
                using (var sqlAdpt = new SqlDataAdapter(query, conn))
                {
                    sqlAdpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    var results = new DataSet();
                    sqlAdpt.Fill(results);
                    myResultsList= results.Tables[0].AsEnumerable().
                    Select(dataRow => new MyModel
                        {
                            id = dataRow.Field<string>("ID"),
                            numberOfID = dataRow.Field<int>("Number Of ID")
                        }).ToList();
                
                }
                return View(myResultsList);
            }
        }
