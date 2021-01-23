    public Form1()
    {
        InitializeComponent();
        DataGridViewColumn dgViewColumn = new DataGridViewTextBoxColumn();
        dgViewColumn.DataPropertyName = "dgViewColumn";
        dgViewColumn.HeaderText = @"dgViewColumn";
        dgViewColumn.Name = "dgViewColumn";
        userControl11.MyDataGridColumns.Add(dgViewColumn);
    }
