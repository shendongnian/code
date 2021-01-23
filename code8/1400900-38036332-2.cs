    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        string connectionString = null;
        connectionString = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString;
        con.ConnectionString = connectionString;
        string medicinename = dataGridView1.Rows[e.RowIndex].Cells["Medicine_Name"].Value.ToString();
        // This is the hypothetical field where the user types the quantity of medicine sold.
        // It could be a cell of your datagridview or just a textbox somewhere in
        // your form. Here I suppose a cell of the grid.
        int Medicine_SoldQuantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex]
                                            .Cells["Medicine_Sold_Qty"].Value);
        DialogResult dialogResult = MessageBox.Show("Are you sure you want to insert data", 
                                     "Data insert Confirmation", 
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Information);
        if (dialogResult == DialogResult.Yes)
        {
            // Here the field total_available is used in the expression
            // to decrement itself of the value extracted from Medicine_SoldQuantity
            cmd = new OleDbCommand(@"update Medicine_Available_Detail 
                     set [total_available]=[total_available]-@medicineSoldQty 
                     where [Medicine_Name]=@Medicine_Name", con);
            cmd.Parameters.AddWithValue("@medicineSoldQty", Medicine_SoldQuantity);
            cmd.Parameters.AddWithValue("@Medicine_Name", medicinename);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
                  MessageBox.Show("Record Updated Successfully");
            con.Close();
            userlist();
            dataGridView1.Refresh();
        }
    }
