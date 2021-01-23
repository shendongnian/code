    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        decimal qty = Convert.ToDecimal(dataGridView1.Rows[x].Cells[4].Value);
        string itemName = dataGridView1.Rows[x].Cells[1].Value;
        string commandText = "UPDATE Pharmacy_Items Set Quantity= Quantity + @p1 WHERE ItemName = @p2";
        SqlCommand cmd2 = new SqlCommand(commandText, mycon);
        cmd2.Parameters.AddWithValue("@p1", qty);
        cmd2.Parameters.AddWithValue("@p2", itemName);
    
        cmd2.ExecuteNonQuery();
    }
