    using (SqlDataReader sdr = cmd.ExecuteReader())
    {
        CityCheckBoxList.DataBind();
        while (sdr.Read())
        {
            EmployeeIdTextBox.Text = sdr["EmployeeID"].ToString();
            EmployeeNameTextBox.Text = sdr["EmployeeName"].ToString();    
            
            ListItem currentCheckBox = CityCheckBoxList.Items.FindByValue(sdr["CityID"].ToString());
            if (currentCheckBox != null)
            {
                currentCheckBox.Selected = true;
            }
        }
    }
