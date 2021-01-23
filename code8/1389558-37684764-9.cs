    using(var con = new SqlConnection(strConnString))
    {
        con.Open();
        var query = "SELECT * FROM CustomerDetails WHERE CustomerName = @name";
        using(var com = new SqlCommand(query,con))
        {
            // This will help avoid any nastiness with your existing syntax
            com.Parameters.AddWithValue("@name", Convert.ToString(Session["New"]));
            // Execute your query here
        }
    }
