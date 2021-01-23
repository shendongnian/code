    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //create DataTable
            DataTable dt = CreateCustomDataTable();
            var pivotDt = dt.AsEnumerable()
            .GroupBy(x => x.Field<int>("RowNum"))
            .Select(grp => new
            {
                BG_Color = grp.First().Field<string>("BG_Color").ToLower(), //System.Drawing.Color.FromName(grp.First().Field<string>("BG_Color")),
                Emp1 = grp.Where(e => e.Field<int>("ColNum") == 1).Select(a => a.Field<int>("EmpId")).SingleOrDefault(),
                Emp2 = grp.Where(e => e.Field<int>("ColNum") == 2).Select(a => a.Field<int>("EmpId")).SingleOrDefault(),
                Emp3 = grp.Where(e => e.Field<int>("ColNum") == 3).Select(a => a.Field<int>("EmpId")).SingleOrDefault()
            }).ToList();
            dataGridView1.DataSource = pivotDt;
            dataGridView1.Columns[0].Visible = false;
        
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            e.CellStyle.BackColor = Color.FromName(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            e.CellStyle.SelectionBackColor = Color.Transparent;
        }
    //...
    }
