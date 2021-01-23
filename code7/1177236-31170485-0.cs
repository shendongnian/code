        public Form1()
        {
            InitializeComponent();
            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;
        }
        void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = comboBox1.Items.Add(e.ClickedItem.Text);
            comboBox1.SelectedIndex = index;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
        }
