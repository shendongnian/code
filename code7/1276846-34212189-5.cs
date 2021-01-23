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
    
                // In this part below, I want the SqlDataReader  to 
                // read all of the records from database returned, 
                // and I want the result to be returned as Array or 
                // Json type, but I don't know how to write this part.
    
                while(reader.Read())
                {
                    List<data> result = new List<data>();
                    var d=new data();
                    d.date=reader[0]; // Probably needs fixing
                    d.name=reader[1]; // Probably needs fixing
                    d.numbers=reader[2]; // Probably needs fixing
                    result.Add(data);
                }
    
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
