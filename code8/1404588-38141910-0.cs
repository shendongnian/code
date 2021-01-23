    mycon.Open();
    SqlCommand cmd = new SqlCommand("SELECT p.ItemName, p.Price1, o.ColumnFromOtherTable FROM Pharmacy_Items p INNER JOIN OtherTable o ON p.ID = o.ID", mycon);
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Data1.Rows.Add();
        Data1.Rows[x].Cells[0].Value = reader["ItemName"].ToString();
        Data1.Rows[x].Cells[1].Value = reader["Price1"].ToString();
        Data1.Rows[x].Cells[2].Value = reader["ColumnFromOtherTable"].ToString();
        x++;
    }
    mycon.Close();
