    protected void btnAddDropDown_Click1(object sender, EventArgs e)
        {
            string city = txtOtherCity.Text.Trim();
            DataTable dt=new DataTable();
            if (!string.IsNullOrEmpty(city))
            {
                // Your code to insert the value of the city from the 'txtOtherCity'           `TextBox` to the respective table
                 //Edit: this is a very rudimentary code
                 string query = "INSERT INTO Career.Location (State) " + 
                       "VALUES (@city) ";
    
        // create connection and command
          using(SqlConnection cn = new SqlConnection(connectionString))
          using(SqlCommand cmd = new SqlCommand(query, cn))
           {
            // define parameters and their values
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = city;
    
            // open connection, execute INSERT, close connection
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
                
            }
            using(SqlConnection cn = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(query, cn))
           {
              query = "select State from Career.Location";
            cn.Open();
            dt=cmd.ExecuteDataTable();
            cn.Close();
                
            }
             ddlLocation.DataSource=dt;
             ddlLocation.DataTextField = "State";
             ddlLocation.DataValueField = "State";
             ddlLocation.DataBind();
            }
        }
