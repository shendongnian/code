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
            var selectedRowIndices = dataGridView1.SelectedRows
                .OfType<DataGridViewRow>()
                .Select(row => row.Index)
                .ToArray();
            foreach (var index in selectedRowIndices)
                dataGridView1.Rows.RemoveAt(index);
            dataGridView1.ClearSelection();
        }
    }
