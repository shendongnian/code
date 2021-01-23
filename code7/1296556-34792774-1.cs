    namespace SQL_Server_TwoList
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                DataOperations dataOps = new DataOperations();
                if (dataOps.LoadData())
                {
                    listBox1.DataSource = dataOps.Names;
                    listBox2.DataSource = dataOps.Titles;
                }
            }
        }
    }
