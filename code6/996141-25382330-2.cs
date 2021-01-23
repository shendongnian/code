     protected void btnAddDropDown_Click1(object sender, EventArgs e)
            {
              string strconnection =            System.Configuration.ConfigurationManager.AppSettings["YourConnectionString"].ToString();
                string city = txtOtherCity.Text.Trim();
                DataSet ds=new DataSet();
                if (!string.IsNullOrEmpty(city))
                {
                    // Your code to insert the value of the city from the 'txtOtherCity'           `TextBox` to the respective table
                     //Edit: this is a very rudimentary code
                     string query = "INSERT INTO Career.Location (State) " + 
                           "VALUES (@city) ";
        
            // create connection and command
              using(SqlConnection cn = new SqlConnection(strconnection))
              using(SqlCommand cmd = new SqlCommand(query, cn))
               {
                // define parameters and their values
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = city;
        
                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                    
                }
                query = "select State from Career.Location";
                using(SqlConnection cnn = new SqlConnection(strconnection))
                using(SqlCommand cmdd = new SqlCommand(query, cnn))
               {  
                SqlDataAdapter adp = new SqlDataAdapter(cmdd);            
                cnn.Open();
                adp .Fill(ds);
                cnn.Close();
                    
                }
                 ddlLocation.DataSource=ds;
                 ddlLocation.DataTextField = "State";
                 ddlLocation.DataValueField = "State";
                 ddlLocation.DataBind();
                }
            }
