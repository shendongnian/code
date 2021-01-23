    public MainForm()
        {
            InitializeComponent();
            //show a dialog, creating the Project-object
            BindingSource bs = new BindingSource();
            bs.DataSource = Project.Persons;
            dataGridView1.DataSource = bs;
            dataGridView1.DataBind();  
        }
