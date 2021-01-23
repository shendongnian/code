    private DataTable _dataTable;
    protected void Page_Load(object sender, EventArgs e)
    {
       InitializeTable();
    }
    private void InitializeTable()
    {        
            if (_dataTable != null) return;
            _dataTable = new DataTable();
            DataColumn dc = new DataColumn("Name");
            _dataTable.Columns.Add(dc);
    }
    protected void Buton1_Click(object sender, EventArgs e)
    {
      DataRow dr = _dataTable.NewRow();
      dr["Name"] = TextBox1.Text;
      _dataTable.Rows.Add(dr);
      _dataTable.AcceptChanges();
      GridView1.DataSource = _dataTable;
      GridView1.DataBind();
    }
