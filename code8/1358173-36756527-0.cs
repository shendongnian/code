    private DataGridView parentDGV;
    public Form2(DataGridView parentDGV)
    {
          InitializeComponent();
          this.parentDGV = parentDGV;
    }
    private void PBX_Logger_Load(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToAddRows = false;
        
        // Your code to fill the DataSource.
        foreach (DataGridViewRow row in parentDGV.Rows)
        {
            string colName = row.Cells["Column"].Value.ToString();
            int size = 0;
            int.TryParse(row.Cells["Column size"].Value.ToString(), out size);
            dataGridView1.Columns[colName].Width = size;
            dataGridView1.Columns[colName].Visible = (bool)row.Cells["Chk"].Value;
        }
    }
