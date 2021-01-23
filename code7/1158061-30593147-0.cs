      public Form1()
        {
            InitializeComponent();
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            dataGridView1_CellClick(this.dataGridView1, new DataGridViewCellEventArgs(0, 0));
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("" + e.ColumnIndex + e.RowIndex);
        }
