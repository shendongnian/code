     Dictionary<string, DataGridView> dic;
        public Form1()
        {
            InitializeComponent();
            dataGridView2.Columns.Add("nekaj", "nekaj");
            dataGridView2.Columns.Add("nekaj", "nekaj");
            dataGridView2.Columns.Add("nekaj", "nekaj");
            dataGridView2.Rows.Add("1", "2", "3");
            dataGridView2.Rows.Add("1", "2", "3");
            dataGridView2.Rows.Add("1", "2", "3");
            dic = new Dictionary<string, DataGridView>();
            dic.Add("test", dataGridView2);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewColumn columns in dic["test"].Columns)
            {
                dataGridView1.Columns.Add(columns.Name, columns.HeaderText);
            }
            foreach(DataGridViewRow rows in dic["test"].Rows)
            {
                ArrayList list = new ArrayList();
              
              foreach(DataGridViewCell cell in rows.Cells)
                {
                    list.Add(cell.Value);
                }
                dataGridView1.Rows.Add(list.ToArray());
             
            }
