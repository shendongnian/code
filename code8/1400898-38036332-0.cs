    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        string connectionString = null;
        connectionString = ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString;
        con.ConnectionString = connectionString;
        string medicinename = dataGridView1.Rows[e.RowIndex].Cells["Medicine_Name"].Value.ToString();
        // This is the ipothetical field where the user types the medicine sold.
        // It could be a cell of your datagridview or just a textbox somewhere in
        // your form. Here I suppose a cell of the grid.
        int medicineSold = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Medicine_Sold"].Value.);
        DialogResult dialogResult = MessageBox.Show("Are you sure you want to insert data", "Data insert Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (dialogResult == DialogResult.Yes)
        {
            cmd = new OleDbCommand(@"update Medicine_Available_Detail 
                set [total_available]=[total_available]-@medicineSold 
                     where [Medicine_Name]=@Medicine_Name", con);
            cmd.Parameters.AddWithValue("@medicineSold", medicineSold);
            cmd.Parameters.AddWithValue("@Medicine_Name", medicinename);
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
            userlist();
            dataGridView1.Refresh();
        }
    }
