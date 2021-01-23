    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            DataTable dt = new DataTable();
            dt.Columns.Add("Foo");
            DataRow row1 = dt.NewRow();
            row1["Foo"] = "BAR";
            DataRow row2 = dt.NewRow();
            row2["Foo"] = "BAZZ";
    
            dt.Rows.Add(row1);
            dt.Rows.Add(row2);
    
            dataGridView1.DataSource = dt;
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Foo] = '{0}'", textBox1.Text);
        }
    }
