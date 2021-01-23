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
            ds1.ReadXmlSchema("XMLFile1Schema.xml");
            ds1.ReadXml("XMLFile1.xml", XmlReadMode.ReadSchema);
            bs1.DataSource = ds1.Tables[0];
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
