    protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationDatabaseConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "INSERT into Customers (CustUserName, CustPassword, CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, CustBusPhone, CustEmail) values (@custUsername ,@custPassword ,@custFirstName ,@custLastName ,@custAddress ,@custCity ,@custProv ,@custPostal, @custCountry ,@custHomePhone ,@custBusPhone ,@custEmail)";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.Parameters.Add("@custUsername", txtCustUserName.Text);
                com.Parameters.Add("@custPassword", txtCustPassword.Text);
                com.Parameters.Add("@custFirstName", txtCustFirstName.Text);
                com.Parameters.Add("@custLastName", txtCustLastName.Text);
                com.Parameters.Add("@custAddress", txtCustAddress.Text);
                com.Parameters.Add("@custCity", txtCustCity.Text);
                com.Parameters.Add("@custProv", txtCustProv.Text);
                com.Parameters.Add("@custPostal", txtCustPostal.Text);
                com.Parameters.Add("@custCountry", txtCustCountry.Text);
                com.Parameters.Add("@custHomePhone", txtCustHomePhone.Text);
                com.Parameters.Add("@custBusPhone", txtCustBusPhone.Text);
                com.Parameters.Add("@custEmail", txtCustEmail.Text);
    
                com.CommandType = CommandType.Text;
                
                com.ExecuteNonQuery();
                Response.Redirect("Manager.aspx");
                Response.Write("Registration is successful" );
    
                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Error:"+ex.ToString());
            }
        }
    }
