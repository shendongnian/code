    private void ShowData()
    {
        using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.ConnString))
        {
           cn.Open();
           sda = new SqlDataAdapter("select key_seq, po_no, ref_no from mpo_master", cn);
           ds = new DataSet();
           sda.Fill(ds, "MPO");
           dataGridView1.DataSource = ds.Tables["MPO"]; 
           cn.Close();
        }
    }
