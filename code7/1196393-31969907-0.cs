    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> list1 = new List<KeyValuePair<int, string>>();
            list1.Add(new KeyValuePair<int, string>(1, "string 1"));
            list1.Add(new KeyValuePair<int, string>(2, "string 2"));
            list1.Add(new KeyValuePair<int, string>(3, "string 3 is too long."));
            list1.Add(new KeyValuePair<int, string>(4, "string 4"));
            list1.Add(new KeyValuePair<int, string>(5, "string 5"));
            dataGridView1.DataSource = list1;
            DgvValidator();
        }
        private void DgvValidator()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (((string)row.Cells[1].Value).Length > 10)
                    row.Cells[1].ErrorText = "ERROR!";
            }
        }
    }
