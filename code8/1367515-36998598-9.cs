    DataGridView dataGridView1 = new DataGridView();
    DataTable DT = null;
    public Form1()
    {
        InitializeComponent();
        dataGridView1.DataSourceChanged += dataGridView1_DataSourceChanged;
    }
