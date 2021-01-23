    protected void Button2_Click(object sender, EventArgs e)
    {
         // Build your query
         var query = "INSERT INTO [Order] VALUES(@V1,@V2,@Quantity,@V3,@V4)";
         // Build your command
         using(var cmd = new SqlCommand(query,con))
         {
              // Consider explicitly opening your connection if it isn't open
              con.Open();
              // Add your parameters
              cmd.AddWithValue("@V1",DropDownList1.SelectedValue);
              cmd.AddWithValue("@V2",DropDownList2.SelectedValue);
              cmd.AddWithValue("@Quantity",txtQuantity.Text);
              cmd.AddWithValue("@V3",DropDownList3.SelectedValue);
              cmd.AddWithValue("@V4",TextBox1.Text);
              // Execute your query
              cmd.ExecuteNonQuery();
              // Clear your parameters and other stuff here
         }
    }
  
