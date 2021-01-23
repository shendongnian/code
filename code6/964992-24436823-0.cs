         public AddDestination()
        {
            InitializeComponent();
        }
        private void AddDestination_Load(object sender, EventArgs e)
        {
            //Give cursor focus to the textbox
            textBox1.Focus();
            //Highlights text **DOES NOT WORK
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }
