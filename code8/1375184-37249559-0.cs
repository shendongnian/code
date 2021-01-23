     namespace emp_db1
    {
        public partial class Print : Form
    {
        List<CheckBox> chkboxes = new List<CheckBox>();
        private OleDbConnection connection = new OleDbConnection();
        public Print()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = emp_0.mdb";
        }
        DataTable ds;
        private void Print_Load(object sender, EventArgs e)
        {
        chkboxes.Add(dob_check); //0
        chkboxes.Add(mother_check); //1
 
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT ID, Name, DOB, Mother FROM emp_per";
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                ds = new DataTable();
                da.Fill(ds);
                dataGridView1.DataSource = ds;
                da.Update(ds);
                connection.Close();
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeColumnHeadersHeight();
               
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void refreshCheckBoxes(int id)
        {
            for(int x = 0; x < 2; x++)
            {
                if (!chkboxes[x].Checked) dataGridView1.Columns[x+2].Visible = false; else dataGridView1.Columns[x+2].Visible = true;
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dob_check_CheckedChanged(object sender, EventArgs e)
        {
            refreshCheckBoxes(0);
        }
        private void mother_check_CheckedChanged(object sender, EventArgs e)
        {
            refreshCheckBoxes(1);
        }
        }
    }
