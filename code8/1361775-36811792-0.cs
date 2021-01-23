    void metroButton1_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                con = new SqlConnection(cs.DBcon);
                con.Open(); //Open the connection
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_employee VALUES(@Designation, @Date, @Employee_name,@Leave,@L_Reason,@Performance,@Payment,@Petrol,@Grand_Total)", con)) //Now create the command
                {
                    cmd.Parameters.AddWithValue("@Designation", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Date", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Employee_name", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Leave", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@L_Reason", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Performance", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Payment", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Petrol", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Grand_Total", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            MessageBox.Show("Records inserted.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
