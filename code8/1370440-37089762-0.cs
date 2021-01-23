    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }
        
        private void listBoxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //SQL Data Source
            string datasource = "Data Source=LENOVO-NQ;Initial Catalog=JustBuy;Integrated Security=True";
            //Query
            string query = "SELECT * FROM Electronics";
            //ConnectionString
            SqlConnection myConn = new SqlConnection(datasource);
            //SQL Command
            SqlCommand myComm = new SqlCommand(query, myConn);
            //Data Reader
            SqlDataReader myDataReader;
            try
            {
                myConn.Open();
                myDataReader = myComm.ExecuteReader();
                while (myDataReader.Read())
                {
                    string temp = myDataReader.GetString(1);
                    checkedListBox1.Items.Add(temp);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Nothing to show!");
            }
        }
