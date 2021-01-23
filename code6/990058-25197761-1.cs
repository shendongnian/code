    protected void gvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("ADD"))
        {
            TextBox txtAddName = (TextBox)gvEmployeeDetails.FooterRow.FindControl("txtAddName");
            if(string.IsNullOrEmpty(txtAddName.Text))
            {
              MessageBox.Show("Name is empty"); // or some logging, you decide
            }
            else
            {
                TextBox txtAddDesignation = (TextBox)gvEmployeeDetails.FooterRow.FindControl("txtAddDesignation");
                TextBox txtAddCity = (TextBox)gvEmployeeDetails.FooterRow.FindControl("txtAddCity");
                TextBox txtAddCountry = (TextBox)gvEmployeeDetails.FooterRow.FindControl("txtAddCountry");
    
                conn.Open();
                string cmdstr = "insert into EmployeeDetails(name,designation,city,country) values(@name,@designation,@city,@country)";
                SqlCommand cmd = new SqlCommand(cmdstr, conn);
                cmd.Parameters.AddWithValue("@name", txtAddName.Text);
                cmd.Parameters.AddWithValue("@designation", txtAddDesignation.Text);
                cmd.Parameters.AddWithValue("@city", txtAddCity.Text);
                cmd.Parameters.AddWithValue("@country", txtAddCountry.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                BindData();
            }
        }
    }
