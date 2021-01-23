    protected void Buton1_Click(object sender, EventArgs e)
    {
    
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("Name");
        dt.Columns.Add(dc);
        DataRow dr = dt.NewRow();
        dr["Name"] = TextBox1.Text;
        dt.Rows.Add(dr);
        dt.AcceptChanges()
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
