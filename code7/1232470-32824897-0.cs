     protected void btnAdd_Click(object sender, EventArgs e)
    {
    
        foreach (ListViewItem item in lvPODetails.Items)
        {
            TextBox quantity = (TextBox)item.FindControl("txtQuantity");
            Literal ltr = (Literal)item.FindControl("ltRefNo");
    
    
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Inventory VALUES (@ProductID, @Quantity)";
            cmd.Parameters.AddWithValue("@ProductID", ltr.Text);
            cmd.Parameters.AddWithValue("@Quantity", quantity.Text);
            cmd.ExecuteNonQuery();
            con.Close();
    
        }
    
    }
