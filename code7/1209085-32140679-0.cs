    private DataTable _dt = new DataTable();  
    private void Form1_Load(object sender, EventArgs e)
    {
            
        _dt.Columns.Add("LongText");
        DataRow dr = _dt.NewRow();
        dr[0] = "One";
        _dt.Rows.Add(dr);
        dr = _dt.NewRow();
        dr[0] = "Two";
        _dt.Rows.Add(dr);
        dr = _dt.NewRow();
        dr[0] = "Three";
        _dt.Rows.Add(dr);
        dataGridView1.DataSource = _dt;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        _dt.Rows[0][0] = "daddy";
    }
