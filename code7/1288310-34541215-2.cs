    string position;
    
    using (SqlConnection con = new SqlConnection("server=free-pc\\FATMAH; Integrated Security=True; database=Workflow; "))
    {
      con.Open();
    
      using (var cmd = new SqlCommand("SELECT EmpName FROM Employee WHERE EmpID = @id", con))
      {
        cmd.Parameters.AddWithValue("@id", id.Text);
      
        var name = cmd.ExecuteScalar();
      
        if (name != null)
        {
           position = name.ToString();
           Response.Write("User Registration successful");
        }
        else
        {
            Console.WriteLine("No Employee found.");
        }
      }
    }
	
