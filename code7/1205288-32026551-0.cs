    private List<string> list = new List<string>();
    public Form1()
    {
            InitializeComponent();
            // Data source for you dropdown list
            list.Add("First Option");
            list.Add("Second Option");
            list.Add("Third Option");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            dataGridView1.DataError += dataGridView1_DataError;
            // Formatting your ComboBox
            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.FlatStyle = FlatStyle.Flat;
            comboColumn.HeaderText = "Hybrid Data Grid Column";
            comboColumn.DataPropertyName = "Tag";
            //comboColumn.DataSource = list;        
            dataGridView1.Columns.Add(comboColumn);
            dataGridView1.DataSource = list;
           
    }
