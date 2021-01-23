    public Form1()
    {
        InitializeComponent();
        dataGridView4.DataSourceChanged += dataGridView4_DataSourceChanged;
    }
    void dataGridView4_DataSourceChanged(object sender, EventArgs e)
    {
        DataGridView datagrid = sender as DataGridView;
        if (datagrid != null)
        {
           datagrid.Columns["some_column_name"].Visible = false;
        }
    }
