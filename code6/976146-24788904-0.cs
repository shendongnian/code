    protected void textBox1_TextChanged(object sender, EventArgs e)
    {
        BindGrid(textBo1.Text);
    }
    private void BindGrid(string teller)
    {
         using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@teller", teller);
                    cmd.ExecuteNonQuery();
                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Session]");
                    dataGridView1.DataSource = ds.Tables["[Session]"];
                    dataGridView1.BindGrid();
                }
    }
