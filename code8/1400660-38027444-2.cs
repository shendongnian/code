    SqlCommand cm = new SqlCommand(@"Select StockID,FoodId,StockName,StockDate,
                                   StockNum,UnID,StockMin,StockCalulate 
                                   from StockCalutale", Conn);
    try
    {
        int currency = 0;
        // When input comes from the user don't trust its input, use a 
        // foolproof way to check its input....
        if(!Int32.TryParse(txtAmount.Text, out currency))
        {
            MessageBox.Show("Invalid currency value!");
            return;
        }
        SqlDataReader dr = cm.ExecuteReader();
        while (dr.Read())
        {
            // Also this line is risky. I assume that you never have null values
            // in this StockCalulate field otherwise you need to check with dr.IsDbNull
            int value = Convert.ToInt32(dr["StockCalulate"].ToString());
            int newStock = value * currency;
            ListViewItem item = new ListViewItem(dr["StockID"].ToString());
            item.SubItems.Add(dr["FoodId"].ToString());
            item.SubItems.Add(dr["StockName"].ToString());
            item.SubItems.Add(dr["StockDate"].ToString());
            item.SubItems.Add(dr["StockNum"].ToString());
            item.SubItems.Add(dr["UnID"].ToString());
            item.SubItems.Add(dr["StockMin"].ToString());
            item.SubItems.Add(newStock.ToString());
            listView1.Items.Add(item);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "EROR");
    }
