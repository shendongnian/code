        Form1 f;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            f = parent;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            f.comboBox1.Items.Add("item");
        }
