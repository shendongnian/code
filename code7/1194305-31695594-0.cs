    public partial class Form1 : Form
    {
        DataSet ds1 = new DataSet();
        BindingSource bs1 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }
        //Initial
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Column1");
            dt1.Columns.Add("Column2");
            dt1.Rows.Add("A11", "A12");
            dt1.Rows.Add("A21", "A22");
            ds1.Tables.Add(dt1);
            bs1.DataSource = ds1.Tables[0];
            //dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.DataSource = bs1;
        }
        //Change content
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Column1");
            dt2.Columns.Add("Column2");
            dt2.Rows.Add("B11", "B12");
            dt2.Rows.Add("B21", "B22");
            dataGridView1.DataSource = dt2;
        }
        //Reset
        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.DataSource = bs1;
        }
    }
