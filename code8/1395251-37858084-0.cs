    public Form1()
    {
        //InitializeComponent();
        var dataTable = new DataTable();
        // Assume that DataTable is populated from database.
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Age", typeof(int));
        dataTable.Rows.Add("John", 42);
        dataTable.Rows.Add("Smit", 33);
        var dataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
        dataGridView.DataSource = dataTable;
        var listBoxNames = new ListBox { Parent = this, Top = dataGridView.Bottom + 10 };
        listBoxNames.DataSource = dataTable;
        listBoxNames.DisplayMember = "Name";
        var labelName = new Label { Parent = this, Top = listBoxNames.Top, Left = listBoxNames.Right + 20 };
        labelName.DataBindings.Add("Text", dataTable, "Name");
        var textBoxName = new TextBox { Parent = this, Top = labelName.Bottom + 10, Left = labelName.Left };
        textBoxName.DataBindings.Add("Text", dataTable, "Name");
        var numericAge = new NumericUpDown { Parent = this, Top = textBoxName.Bottom + 10, Left = textBoxName.Left };
        numericAge.DataBindings.Add("Value", dataTable, "Age");
    }
