    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Top_Shine_Form Tsf;
        private void button1_Click(object sender, EventArgs e)
        {
            Tsf.dataGridView1.CurrentCell.Value += "    X";
            this.Close();
        }
    }
    public partial class Top_Shine_Form : Form
    {
        ...
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var form3 = new Form3();
            form3.Tsf = this;
            form3.ShowDialog();
        }
        ...
    }
