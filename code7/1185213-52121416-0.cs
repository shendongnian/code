    SqlCommand cmd = new SqlCommand("INSERT INTO Product_table Values(@Product_Name, @Product_Price, @Product_Profit, @p)", connect);
    cmd.Parameters.Add("@Product_Name", SqlDbType.NVarChar, ProductNameSizeHere).Value = txtProductName.Text;
    cmd.Parameters.Add("@Product_Price", SqlDbType.Int).Value = txtProductPrice.Text;
    cmd.Parameters.Add("@Product_Profit", SqlDbType.Int).Value = txtProductProfit.Text;
    cmd.Parameters.Add("@p", SqlDbType.NVarChar, PSizeHere).Value = txtP.Text;
    cmd.ExecuteNonQuery();
