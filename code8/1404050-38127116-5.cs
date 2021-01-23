    public Form1()
        {
            InitializeComponent();
            this.button_OK.Click += new EventHandler(button_OK_Click);
            this.button_Cancel.Click += new EventHandler(button_Cancel_Click);
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Add text", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                string fileName = @"c:\\Test.txt";
                string textToAdd = textBox1.ToString();
                
                string newTime = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
                try
                {
                    File.AppendAllText(fileName, String.Format("{0} {1} {2}", newTime, System.Environment.UserName, textToAdd));
                    MessageBox.Show("You have successfully added this entry to the key files.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error adding this entry to the key files.");
                }
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Form1 myForm = new Form1();
            if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
