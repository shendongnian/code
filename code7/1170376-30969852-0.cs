                public Form1()
        {
            InitializeComponent();
            AddItems();
        }
        public void AddItems()
        {
            listBox1.Items.Clear();
            string[] filenames = new[] { "music a", "music b" };
            listBox1.Items.AddRange(filenames);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = "music a";
            int index1 = listBox1.Items.IndexOf(curItem);
            if (index1 != -1)
            {
                MessageBox.Show(curItem);
            }
        }
