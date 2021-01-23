    private void button1_Click(object sender, EventArgs e)
    {
        cn.Open();
        foreach (DataGridViewRow row in Order_Datagridview.Rows)
        {
            SqlCommand cmd = new SqlCommand("UPDATE MEDICINE_REGISTRATION SET stock = " + row.cless["RStock"].Value + "  WHERE id= " + row.Cells["id"].Value.ToString() + " ", cn);
            MessageBox.Show(cmd.ExecuteNonQuery());
         }
         
        cn.Close();
    }
