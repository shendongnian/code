    private void Update_OrderDetails_Click(object sender, EventArgs e)
    {
    	string sql = @"insert Customer_Order_Details 
    	    (Order_Number, DateTime, Qty, Description, Price)
    		values
    		(@OrderNumber, @DateTime@Qty, @Qty, @Description, @Price)";
    
    	using (SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=mydb;Integrated Security=True"))
    	using (SqlCommand cm = new SqlCommand(sql, cn))
    	using (SqlCommand delete = new SqlCommand("delete from Customer_Order_Details where Order_Number = @OrderNumber"))
    	{
    
    		cm.Parameters.AddWithValue("@OrderNumber", 3);
    		cm.Parameters.AddWithValue("@DateTime", new DateTime(2015, 12, 17, 15, 4, 57, 43));
    		cm.Parameters.AddWithValue("@Qty", 0);
    		cm.Parameters.AddWithValue("@Description", "");
    		cm.Parameters.AddWithValue("@Price", 0M);
    
    		delete.Parameters.AddWithValue("@OrderNumber", 3);
    
    		cn.Open();
    		delete.ExecuteNonQuery();
    
    		foreach (DataGridViewRow row in dataGridView2.Rows)
    		{
    			cm.Parameters["@Qty"].Value = row.Cells[2].Value;
    			cm.Parameters["@Description"].Value = row.Cells[3].Value;
    			cm.Parameters["@Price"].Value = row.Cells[4].Value;
    			cm.ExecuteNonQuery();
    		}
    		cn.Close();
    	}
    }
