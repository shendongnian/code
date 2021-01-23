        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string YourValue, int AnotherValue)     //This basically works like a constructor when the form is called
        {
            InitializeComponent();
            ValueLabel1.Text = YourValue;
            ValueLabel2.Text = Convert.ToString(AnotherValue);
        }
        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            int a = 3;
            Form1 Window = new Form1(TextBox1.Text, a);
            Window.Show;
        }
