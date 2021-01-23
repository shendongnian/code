    public Form1()
        {
            InitializeComponent();
            load_input_table();
            load_output_table();
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        
        static String conn = @"Data Source=SUMEET-PC\MSSQLSERVER1;Initial Catalog=EMIDS;Integrated Security=True";
        SqlConnection connection = new SqlConnection(conn);
        DataGridViewComboBoxColumn inputtablecombobox = new DataGridViewComboBoxColumn();
                  
        private void load_input_table()
        {
            String sql = "select * from input_metadata";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            BindingSource b = new BindingSource();
            b.DataSource = table;
            dataGridView1.DataSource = b;
            addcombo();
            
        }
        
        private void addcombo()
        {
            inputtablecombobox.HeaderText = "field";
            inputtablecombobox.Name = "inputtablecombobox";
            String combosql = "select field from input_metadata";
            SqlDataAdapter comboadapter = new SqlDataAdapter(combosql, connection);
            DataSet ds = new DataSet();
            comboadapter.Fill(ds);
            inputtablecombobox.DataSource = ds.Tables[0];
            inputtablecombobox.DisplayMember = "field";
            inputtablecombobox.ValueMember = "field";
            dataGridView1.Columns.Add(inputtablecombobox);
        }
        
        private void load_output_table()
        {
            String sql = "select * from output_metadata";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            BindingSource b = new BindingSource();
            b.DataSource = table;
            dataGridView2.DataSource = b;
        }
        
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(inputtablecombobox_SelectedIndexChanged);
                combo.SelectedIndexChanged += new EventHandler(inputtablecombobox_SelectedIndexChanged);
            }
        }
        private void inputtablecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(text);
        }
    }
