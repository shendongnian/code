    if (reader.Read())
    {
       OleDbCommand cmd = new OleDbCommand(@"Update TblInventory set 
       Quantity = Quantity + @Quantity WHERE ItemCode = @itemcode");
       cmd.Connection = con;
       cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(row.Quantity));
       cmd.Parameters.AddWithValue("@itemcode", row.Item);
       cmd.Parameters.AddWithValue("@DateAndTime", time);
       
       if (Quantity >= Convert.ToInt32(row.Quantity))
       {
           cmd.ExecuteNonQuery();
           MessageBox.Show("You added " + row.Quantity + " " + row.Product, "Existing Item");
       }
       else
       {
           MessageBox.Show("Quantity must not be negative.");
       }
    }
