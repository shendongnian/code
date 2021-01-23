        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button1_Click);
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // OR
            this.button1.Click += (s, a) => ShowMessageBox("Test1");
            this.button2.Click += (s, a) => ShowMessageBox("Test2");
            this.button3.Click += (s, a) => ShowMessageBox("Test3");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Event World");
        }
        private void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
