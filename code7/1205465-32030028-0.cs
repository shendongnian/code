    public Form2(string form1data)
    {
        InitializeComponent();
        SymbolData sd = new SymbolData(form1data);
        dataGridView1.DataSource = sd.Table;
    }
