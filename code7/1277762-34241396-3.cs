    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows
                .OfType<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .ToArray();
            foreach (var row in selectedRows)
                dataGridView1.Rows.Remove(row);
            dataGridView1.ClearSelection();
        }
    }
