    DataTable dt = new DataTable();
    private void Form1_Load(object sender, EventArgs e)
    {
        displaytrail();
    }
    private void displaytrail()
    {
        cm = new SqlCommand();
        cn = new SqlConnection(lgn.connections);
        cn.Open();
        cm.Connection = cn;
        query = "Select * from Trails";
        cm.CommandText = query;
        SqlDataAdapter dar = new SqlDataAdapter(cm);        
        dar.Fill(dt);
        dataGridView1.DataSource = dt;
        dataGridView1.Columns[0].Width = 0;
        dataGridView1.Columns[1].Width = 130;
        dataGridView1.Columns[2].Width = 100;
        dataGridView1.Columns[3].Width = 360;
        dataGridView1.Columns[4].Width = 130;
        this.dataGridView1.Columns[0].Visible = false;
    }
    private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataView dv = dt.DefaultView;
        dv.RowFilter = string.Format("TRANSACTYPE  LIKE '%{0}%'", cboFilter.SelectedItem.ToString());
        dataGridView1.DataSource = dv;
    }
