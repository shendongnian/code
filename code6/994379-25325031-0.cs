    public Form1()
        {
            InitializeComponent();
        }
        List<string> liststrings = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            liststrings.Add(textBox1.Text);
            liststrings.Add(textBox2.Text);
            liststrings.Add(textBox3.Text);
            
            var form2 = new Form2(liststrings);
            form2.Show();
            this.Hide();
            
        }
