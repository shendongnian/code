    public Form1()
    {
        InitializeComponent();
        Load += new EventHandler(Form1_Load); // or use the form designer
    }
    
    private void Form1_Load(object sender, System.EventArgs e)
    {
        comboBox1.DataSource = cse.tblProductTypes;
        comboBox1.DisplayMember = "Description";
        comboBox1.ValueMember = "ProductType";
    }
