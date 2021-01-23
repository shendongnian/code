    private void Update_OrderDetails_Click(object sender, EventArgs e)  
    {
        string cmdText = @"INSERT INT Customer_Order_Details 
             (Order_Number, DataTime, Qty, Description, Price) 
             VALUES(@Order_Number, @DateTime, @Qty, @Description, @Price)";
        // Put every disposable objects inside a using block
        using(SqlConnection cn = new SqlConnection(....))
        {
            cn.Open();
            using(SqlTransaction tr = cn.BeginTransaction()) // Start the transaction
            using(SqlCommand cm = new SqlCommand("", cn));
            {
                // Delete the data that you are ready to reinsert
                cm.CommandText = @"DELETE FROM Customer_Order_Details 
                                   WHERE Order_Number = @OrderNumber 
                                   AND DateTime = @DateTime";
                cm.Parameters.Add("@OrderNumber", SqlDbType.Int).Value = 3;
                cm.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = "2015 - 12 - 17 15:04:57.043";
                cm.ExecuteNonQuery();
                // Change the commandtext, leave the parameters already there and
                // add the parameters required for insert, DO NOT PUT VALUES NOW
                cm.CommandText = cmdCommandText;
                cm.Parameters.Add("@Qty", SqlDbType.Int).Value = 0;
                cm.Parameters.Add("@Description", SqlDbType.Text).Value = "";
                cm.Parameters.Add("@Price", SqlDbType.Money).Value = 0;
                // Loop on your rows and reinsert the records
                for(int rowIndex = 0; x < 3; rowIndex++)
                {
                  cm.Parameters["@Qty"].Value = dataGridView2.Rows[rowIndex].Cells[2].Value;
                  cm.Parameters["@Description"].Value = dataGridView2.Rows[rowIndex].Cells[3].Value;
                  cm.Parameters["@Price"].Value = dataGridView2.Rows[rowIndex].Cells[4].Value;
                  cm.ExecuteNonQuery();
               }
               tr.Commit();
           }
       }
    }
