    namespace GridView
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataSet ds= new DataSet();
                ds.ReadXml(@"C:\Users\user\Desktop\students.xml");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "student";
                Application.DoEvents();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                BindingSource b = new BindingSource();
                dataGridView2.AutoGenerateColumns = true;
                b.DataSource = dataGridView1.DataSource;
                dataGridView2.DataMember = "student";
                dataGridView2.DataSource = b;
            }
        }
    }
