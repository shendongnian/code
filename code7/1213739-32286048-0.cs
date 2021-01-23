	protected void Button1_Click(object sender, EventArgs e)
	{
	    // define your connection string (typically from a .config file) and your query WITH parameters!
	    string connectionString = "Data Source=(local);Initial Catalog=payroll;Integrated Security=True";
	    string query = "SELECT employeeid, role FROM employees WHERE username=@user AND and password=@pwd;";
	
	    // set up a connection and command in using() blocks
	    using (SqlConnection con = new SqlConnection(connectionString))
	    using (SqlCommand cmd = new SqlCommand(query, con))
	    {
	        // add parameters and set their values
    	    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = TextBox1.Text;
	        cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 50).Value = TextBox2.Text;
            // open connection
	        con.Open();
            // establish data reader
	        using (SqlDataReader dr = cmd.ExecuteReader())
	        {
	            // if at least one row is returned....  
     	        if (dr.Read()) 
	            {  
	                // get employee ID and role from the reader
	                string employeeId = dr.GetFieldValue<string>(0);
	                string role = dr.GetFieldValue<string>(1);
	                
	                // depending on role, jump off to various pages
	                switch (role)
	                {
	                    case "admin":
	                       Response.Redirect("Admin.aspx"); 
	                       break;
	                    case "manager":
	                       Response.Redirect("manager.aspx"); 
	                       break;
	                       
	                    default:
	                       Response.Redirect("employee.aspx"); 
	                       break;
                        }
                    } 
                    else
                    {
                       // what do you want to do if NO ROW was returned? E.g. user/pwd combo is wrong
                    }
	            
	            dr.Close();
	        }    
       	    con.Close();
       	}
	}
