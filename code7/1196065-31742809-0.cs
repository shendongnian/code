    public FrmMain()
    {
        InitializeComponent();
        var editColumn = new DataGridViewButtonColumn  //Adding Edit column
        {
            Text = "Edit",
            UseColumnTextForButtonValue = true,
            Name = "Edit",
            DataPropertyName = "Edit"
        };
        dataGridView1.Columns.Add(editColumn);
        var delColumn = new DataGridViewButtonColumn  //Adding Delete Column
        {
            Text = "Delete",
            UseColumnTextForButtonValue = true,
            Name = "Delete",
            DataPropertyName = "Delete"
        };
        dataGridView1.Columns.Add(delColumn);
    
        // Set after adding to collection
        editColumn.DisplayIndex = 3;
        delColumn.DisplayIndex = 4;
    
        DisplayData(); //Method to bind data in gridview
    }
