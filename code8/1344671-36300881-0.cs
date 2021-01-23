        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        
            string value = DropDownList4.SelectedValue.ToString();  // Get the dropdown value 
            int count = 0;
            int.TryParse(value, out count);  // cast the value to integer 
        
            for (int i = 0; i < count; i++)  // iterate it for the N times 
            {
        
                SqlCommand insert = new SqlCommand("insert into Test(Name, Username) values(@Name, @Username)", con);
                insert.Parameters.AddWithValue("@Name", TextBox1.Text);
                insert.Parameters.AddWithValue("@Username", TextBox2.Text);
        
                try
                {
                    con.Open();
                    insert.ExecuteNonQuery();
        
                }
                catch
                {
                    i--;
                }
                finally
                {
                    con.Close();
                }    
            }
            GridView1.DataBind();
        
        }
    
     
