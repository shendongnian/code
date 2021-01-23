    public ActionResult notCk_Pk(String FirstName, String LastName, int? Salary, String Gender)
    {
        List<Counting> l = new List<Counting>();
        
        string query = "select * from tblEm where FirstName = @FirstName";
        string ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        -- set up and connection and command in "using"        
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            -- define parameter - don't use "AddWithValue"
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 100).Value = FirstName;
            -- define data adapter and use the *existing* "cmd"   
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            -- fill a DataTable since you only get data from a single table
            DataTable dt = new DataTable();
            
            da.Fill(dt);
    
            foreach (DataRow dr in dt.Rows)
            {
                l.Add(new Counting() { FirstNamecount = Convert.ToInt32(dr[0]), 
                                       LastNamecount = Convert.ToInt32(dr[1]), 
                                       Salary = Convert.ToInt32(dr[2]), 
                                       Gendercount = Convert.ToInt32(dr[3]) 
                                     });
            }
        }
            
        var todoListsResults = l.Select(
    	  a => new
    	  {
    
    	      a.FirstNamecount,
    	      a.LastNamecount,
    	      a.Salary,
    	      a.Gendercount
    
    	  });
    
        var jsonData = new
            {
                rows = todoListsResults
            };
    
        return Json(jsonData, JsonRequestBehavior.AllowGet);
    }
