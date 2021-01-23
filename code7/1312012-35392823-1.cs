    public Form1()
    {
        InitializeComponent();
        DataGridViewColumn dgViewColumn = new DataGridViewTextBoxColumn();//Or DataGridViewCheckBoxColumn
        dgViewColumn.DataPropertyName = "dgViewColumn";
        dgViewColumn.HeaderText = @"dgViewColumn";
        dgViewColumn.Name = "dgViewColumn";
        userControl11.MyDataGridColumns.Add(dgViewColumn);
    }
