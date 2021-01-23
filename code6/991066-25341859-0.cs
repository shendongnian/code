    private void InitDataGridView(DataGridView dataGridView, string name)
    {
        dataGridView.Name = name;
        // configure other properties here
        dataGridView.Location = new System.Drawing.Point(100, 100);
        dataGridView.RowHeadersWidth = 50;
        dataGridView.RowTemplate.Height = 25;
        dataGridView.Size = new System.Drawing.Size(55 + 50 * 2, 25 + dataGridView1.RowTemplate.Height * 2);
        dataGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
        dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Columns.AddRange(Columns);
        dataGridView.AllowUserToAddRows = false;
        dataGridView.Rows.Add();
        dataGridView.Rows.Add();
        dataGridView.Rows[0].HeaderCell.Value = "i" + 1;
        dataGridView.Rows[1].HeaderCell.Value = "i" + 2;
        dataGridView.Rows[0].Cells[0].Value = "value1";
    }
    public Form1()
    {
        InitializeComponent();
        var dataGridView1 = new DataGridView();
        var dataGridView2 = new DataGridView();
        InitDataGridView(dataGridView1, "dataGridView1");
        InitDataGridView(dataGridView2, "dataGridView2");
    }
