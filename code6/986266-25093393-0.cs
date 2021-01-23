    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable dt;
        private void btn_load_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Select", System.Type.GetType("System.Boolean"));
            dt.Columns.Add("Employee No");
            dt.Columns.Add("Employee Name");
            dt.Columns.Add("Join Date");
            DataRow dr;
            for (int i = 0; i <= 10; i++)
            {
                dr = dt.NewRow();
                dr["Select"] = false;
                dr["Employee No"] = 1000 + i;
                dr["Employee Name"] = "Employee " + i;
                dr["Join Date"] = DateTime.Now.ToString("dd/MM/yyyy");
                dt.Rows.Add(dr);
            }
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = dt;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            //I need the Employee Id values here
            foreach (DataRow row in dt.Rows)
            {
                if ((bool)row["Select"] == true)
                {
                }
            }
        } 
    }
