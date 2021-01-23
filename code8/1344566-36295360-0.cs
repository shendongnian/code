    namespace TowerSearch
    {
        public partial class EditParts : Form
        {
            const string conString = ConString.conString;
            static DataClasses1DataContext PartsLog = new      DataClasses1DataContext(conString);
            static Table<Part> listOfParts = PartsLog.GetTable<Part>();
    
            SqlDataAdapter sda;
            SqlCommandBuilder scb;
            DataTable dt;
    
            public EditParts()
            {
                InitializeComponent();
            }
    
            //Load and refresh the dataGridView
            private void showData()
            {
                SqlConnection con = new SqlConnection(conString);
                sda = new SqlDataAdapter("SELECT * FROM Parts", con);
    
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
    
            private void EditParts_Load(object sender, EventArgs e)
            {
               showData();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    dataGridView1.Refresh();
                    scb = new SqlCommandBuilder(sda);
                    sda.Update(dt);
    
                    MessageBox.Show("Saved");
                    showData();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("There is an error in the data!\nCheck if there are any blank spots besides Quantity.");
                }  
            }
        }
    }
