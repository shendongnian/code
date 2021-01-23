    public partial class GridForm : Form
    {
        public GridForm()
        {
            InitializeComponent();
        }
        //we will this as data source
        private DataTable table;
        private void GridForm_Load(object sender, EventArgs e)
        {
            //Create the data table here and bind it to grid
            table = new DataTable();
            table.Columns.Add(new DataColumn("IName", typeof(string)));
            table.Columns.Add(new DataColumn("Icode", typeof(string)));
            table.Columns.Add(new DataColumn("Quantity", typeof(string)));
            table.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
            table.Columns.Add(new DataColumn("Amount", typeof(string)));
            this.dataGridView1.DataSource = table;
        }
        private void passDataButton_Click(object sender, EventArgs e)
        {
            //When you need to pass data, use Copy method of data table
            var clone = table.Copy();
            //Pass data to other form
            var f = new OtherForm(clone);
            f.ShowDialog();
        }
    }
