        public Form1()
        {
            InitializeComponent();
            var lvi = listView1.Items.Add("2.01");
            lvi.Tag = "Hello";
            lvi = listView1.Items.Add("2.02");
            lvi.Tag = "Goodbye";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                textBox1.Text = listView1.SelectedItems[0].Tag as string;
            }
        }
