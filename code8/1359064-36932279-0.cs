    public partial class Form2 : Form
    {
        string opcode;
        string labelz;
        string operand;
        string m;
        string fg;
        string d;
        int a = 0;
        string value;
        static System.Data.OleDb.OleDbConnection con1 = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=D:/ASSEMBLER.mdb");
        public Form2()
        {
            InitializeComponent();
            grid1();
            grid2();
            grid3();
        }
        private void grid1()
        {
            try
            {
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter adapReport = new System.Data.OleDb.OleDbDataAdapter("select Adress as [address], opcode as [Symbol],operand as [opco],op as [operand],ooo as[obj] from read_pgm" + "'", con1);
                adapReport.Fill(ds, "read_pgm");
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "read_pgm";
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView1.Rows[i].Cells[1].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView1.Rows[i].Cells[2].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView1.Rows[i].Cells[3].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                }
                Int16 b = Convert.ToInt16(dataGridView1.Rows[1].Cells[0].Value);
                //start_address = Convert.ToString(dataGridView1.Rows[1].Cells[0].Value);
                // MessageBox.Show(add + " in second form");
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void grid2()
        {
            con1.Open();
            try
            {
                DataSet ds1 = new DataSet();
                System.Data.OleDb.OleDbDataAdapter adapReport = new System.Data.OleDb.OleDbDataAdapter("select SYMBOLE as [Symbol],ADDRESS as [ADDRESS] from SYMBOL_TABLE" + "'", con1);
                adapReport.Fill(ds1, "SYMBOL_TABLE");
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = ds1;
                dataGridView2.DataMember = "SYMBOL_TABLE";
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView2.Rows[i].Cells[1].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                }
                //Int16 b = Convert.ToInt16(dataGridView1.Rows[1].Cells[0].Value);
                //start_address = Convert.ToString(dataGridView1.Rows[1].Cells[0].Value);
                // MessageBox.Show(add + " in second form");
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //con1.Close();
        }
        private void grid3()
        {
            con1.Open();
            try
            {
                DataSet ds2 = new DataSet();
                System.Data.OleDb.OleDbDataAdapter adapReport = new System.Data.OleDb.OleDbDataAdapter("select opcode as [opcode],val as [value] from Mnemoni" + "'", con1);
                adapReport.Fill(ds2, "Mnemoni");
                dataGridView3.AutoGenerateColumns = true;
                dataGridView3.DataSource = ds2;
                dataGridView3.DataMember = "Mnemoni";
                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    dataGridView3.Rows[i].Cells[0].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    dataGridView3.Rows[i].Cells[1].Style.Font = new Font("Arial", 9, FontStyle.Bold);
                }
                //Int16 b = Convert.ToInt16(dataGridView1.Rows[1].Cells[0].Value);
                //start_address = Convert.ToString(dataGridView1.Rows[1].Cells[0].Value);
                // MessageBox.Show(add + " in second form");
                con1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }## 
