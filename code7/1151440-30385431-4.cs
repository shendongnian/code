    private List<int> dividers = new List<int>() { 2, 5 };
    private int pad = 5;
    
    public Form1()
    {
        InitializeComponent();
        InitializeDataGridView();
    }
    
    private void InitializeDataGridView()
    {
        dataGridView1.AllowUserToAddRows = false;
    
        for (int i = 0; i < 9; i++)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "c" + (i + 1);
            column.Width = 25 + (dividers.Contains(i) ? pad : 0);
            dataGridView1.Columns.Add(column);
        }
    
        for (int i = 0; i < 9; i++)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);
            row.Height = row.Height + (dividers.Contains(i) ? pad : 0);
            dataGridView1.Rows.Add(row);
            foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
            {
                cell.Value = cell.ColumnIndex;
            }
        }
    
        foreach (int div in dividers)
        {
            dataGridView1.Columns[div].DividerWidth = pad;
            dataGridView1.Rows[div].DividerHeight = pad;
        }
    }
