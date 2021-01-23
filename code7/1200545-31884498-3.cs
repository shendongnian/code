    private void MainForm_Load(object sender, EventArgs e)
    {
        _mySqlCeEngine = new MySqlCeEngine(this);
        ShowHomePanel();
        LoadLastVisitedCustomers();
    }
    private void LoadLastVisitedCustomers()
    {
        lbc_lastCustomersVisited.DataSource = new BindingSource(lastVisitedCustomers, null);
        lbc_lastCustomersVisited.DisplayMember = "Value";
        lbc_lastCustomersVisited.ValueMember = "Key";
    }
