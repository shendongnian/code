     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Quantity", Type.GetType("System.Decimal")); // You can change it to Int32
            dt.Columns.Add("Amt", Type.GetType("System.Decimal"));
            dt.Columns.Add("netprice", Type.GetType("System.Decimal"));
            var row = dt.NewRow();
            row["Quantity"] = 1;
            row["Amt"] = 2.5;
            row["netprice"] = 0;
            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
        }
                
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (e.ColumnIndex == dataGridView1.Columns["Quantity"].Index)
                {
                    dataGridView1.EndEdit();
                    decimal quantity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Amt"].Value);
                    decimal netprice = (quantity * price);
                    row.Cells["netprice"].Value = Math.Round((netprice), 2);
                }
            }
            // My suggestion:
            // No need to go through all the rows, just the current one
            /*
            if (e.ColumnIndex == dataGridView1.Columns["Quantity"].Index)
            {
                // dataGridView1.EndEdit(); // No need this line, you are already in CellEndEdit event
                var currentRow = dataGridView1.Rows[e.RowIndex];
                decimal quantity = Convert.ToDecimal(currentRow.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(currentRow.Cells["Amt"].Value);
                decimal netprice = (quantity * price);
                currentRow.Cells["netprice"].Value = Math.Round((netprice), 2);
            }
            */
        }
    }
