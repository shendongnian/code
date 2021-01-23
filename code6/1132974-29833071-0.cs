    protected void itemSelected(object sender, EventArgs e)
    {
        var val = DropDownListCustomerType.SelectedItem.Value;
        using (SqlConnection con = new SqlConnection(myDataConnection)) {
         using (SqlCommand cmd = new SqlCommand("GetLastCustomerID_CustomerTypeSelect", con)) {
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar).Value = val;
      
         con.Open();
         TSCustomerNumber.Text = (String) cmd.ExecuteScalar();
       }
      }
    }
