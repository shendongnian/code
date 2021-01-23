    public class data {
      public DateTime date {get;set;}
      public string name {get;set;}
      public int numbers {get;set;}
    }
    public ActionResult GetAllSummary()
    {
        string connectionString ="Data Source=...;Initial Catalog=...;Integrated Security=True";  
        string query = "SELECT DISTINCT v.date, v.name, v.numbers FROM view as v ORDER BY v.date,v.name,v.numbers";
    
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, conn);
    
            try {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                var dt=new DataTable();
                dt.Load(myDataReader);
                List<DataRow> result=dt.AsEnumerable().ToList();
                reader.Close();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                return View(error);
            }
        }
    
        return View();
    }
