    public partial class AddQuery : Form
    {
        public AddQuery()
        {
            InitializeComponent();
            fill_combo();
        }
        void fill_combo()
        {
            string cmdstr = "select * from sys.tables";
            string conStr = @"Data Source=INPDDBA027\NGEP;Initial Catalog=Dev_Server;Integrated Security=True";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmdstr,conStr);
            try
            {
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row["name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
