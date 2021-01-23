    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonDelete.Enabled = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
    
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = (((DataGridView)sender).SelectedRows.Count > 0);  
        }
    
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.Rows.Add(1, "pizaa", 3);  //add rows to dataGridView;
            dataGridView1.Rows[rowIndex].Selected = true; //select the added row
        }
    
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(index);
                // Select the last row if it exists...
                if (dataGridView1.Rows.Count > 0)
                {
                    index = (index == 0) ? 0 : --index;
                    dataGridView1.CurrentCell.Selected = false;
                    dataGridView1.Rows[index].Selected = true;
                }
            }
        }
    }
