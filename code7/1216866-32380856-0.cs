    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rnawa_000\Documents\Visual Studio 2013\Projects\Random\Random\sales.mdf;Integrated Security=True");
    
    SqlCommand cmd = new SqlCommand();
    
    cmd.Connection = conn;
    conn.Open();
        
    foreach (string item in listBox1.Items)
    {
    	cmd.CommandText = "insert into salesTB (Date,Time,Name,Quantity,Cost,Purchase) values (@date, @time, @name, @quantity, @cost, @purchase)";
    
    	cmd.Parameters.Add(new SqlParameter("date", date.Text));
    	cmd.Parameters.Add(new SqlParameter("time", time.Text));
    	cmd.Parameters.Add(new SqlParameter("name", txtName.Text));
    	cmd.Parameters.Add(new SqlParameter("quantity", listBox1.Items.Count));
    	cmd.Parameters.Add(new SqlParameter("cost", txtCost.Text));
    	cmd.Parameters.Add(new SqlParameter("purchase", item.Substring(0,10)));
    
    	cmd.ExecuteNonQuery();
    	cmd.Clone();
    }
    
    conn.Close();
