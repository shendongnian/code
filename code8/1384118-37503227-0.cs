    public Form1()
        {
            InitializeComponent();
            if(File.Exists(@"path.txt"))
                textBox1.Text = File.ReadAllText(@"path.txt");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(File.Exists(@"path.txt"))
                File.WriteAllText(@"path.txt", textBox1.Text);
            else
            {
                File.Create(@"path.txt");
                File.WriteAllText(@"path.txt", textBox1.Text);
            }
        }
