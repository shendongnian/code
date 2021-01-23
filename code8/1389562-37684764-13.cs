    using(var con = new SqlConnection(strConnString))
    {
        con.Open();
        var query = "SELECT * FROM CustomerDetails WHERE CustomerName = @name AND ID = @id";
        using(var com = new SqlCommand(query,con))
        {
            // This will help avoid any nastiness with your existing syntax
            com.Parameters.AddWithValue("@name", Convert.ToString(Session["New"]));
            com.Parameters.AddWithValue("@id",Convert.ToInt32(Request["Id"]));
    
            // Execute your query
            using(var reader = com.ExecuteReader())
            {
                  if(!reader.HasRows)
                  {
                      // Redirect
                      Response.Redirect("Error.aspx");
                  }  
                  // Do something here
            }
        }
    }
