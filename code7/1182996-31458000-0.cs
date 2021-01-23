         public Form1()
        {
            InitializeComponent();
            
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //whatever you want to happen when the mouse is clicked in a cell.
        }
