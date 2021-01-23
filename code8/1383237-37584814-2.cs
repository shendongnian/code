    private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string xlsSheet = "PR$";
            string name = ds.Tables[0].Rows[0][0].ToString();
            DataTable dt = (DataTable)dgPR.DataSource;
            string changeColumns = "";
            for (int i = 0; i < Table.ColumnName.Count; i++)
            {
                changeColumns += Table.ColumnName[i] + "=@" + Table.ColumnName[i];
                if (Table.ColumnName.Count - 1 != i)
                    changeColumns += ",";
            }
            adap.UpdateCommand = new OleDbCommand("UPDATE [" + xlsSheet + "]  SET " + changeColumns +
                                                                " WHERE " + Table.ColumnName[PrimaryColumnIndex] + " = @" + Table.ColumnName[PrimaryColumnIndex], conn);
            for (int i = 0; i < Table.ColumnName.Count; i++)
            {
                adap.UpdateCommand.Parameters.Add("@" + Table.ColumnName[i], OleDbType.Char, 255).SourceColumn = Table.ColumnName[i];
            }
            foreach (int row in ListOfValues.Keys)
            {
                Table tbl = ListOfValues[row];
                ds.Tables[0].Rows[row][Table.ColumnName[PrimaryColumnIndex]] = ds.Tables[0].Rows[row][PrimaryColumnIndex];
                for (int i = 0; i < tbl.Value.Count; i++)
                {
                    ds.Tables[0].Rows[row][Table.ColumnName[tbl.col[i]]] = tbl.Value[i];
                }
                adap.Update(ds.Tables[0]);
            }
            conn.Close();
            MessageBox.Show("Updated");
        }
        bool isFormLoad = false;
        int PrimaryColumnIndex = 0;
        OleDbDataAdapter adap;
        DataSet ds;
        OleDbConnection conn;
        OleDbCommandBuilder builder;
        Dictionary<int, Table> ListOfValues = new Dictionary<int, Table>();
        public class Table
        {
            public List<string> Value { get; set; }
            public List<int> col { get; set; }
            public static List<string> ColumnName;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=e:\PRTEXT.xls;Extended Properties=Excel 8.0";
            conn.Open();
            adap = new OleDbDataAdapter("SELECT * FROM [PR$]", conn);
            ds = new DataSet();
            adap.Fill(ds, "PR");
            Table.ColumnName = new List<string>();
            foreach (DataColumn str in ds.Tables[0].Columns)
            {
                Table.ColumnName.Add(str.ColumnName);
            }
            dgPR.DataSource = ds.Tables[0];
            conn.Close();
            dgPR.Columns[PrimaryColumnIndex].ReadOnly = true;
            dgPR.RowValidated += new DataGridViewCellEventHandler(dgPR_RowValidated);
            isFormLoad = true;
        }
        private void dgPR_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (isFormLoad)
            {
                Table tbl = new Table();
                DataGridView dgv = (DataGridView)sender;
                tbl.Value = new List<string>();
                tbl.col = new List<int>();
                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    tbl.Value.Add(dgv.Rows[e.RowIndex].Cells[i].Value.ToString());
                    tbl.col.Add(i);
                }
                if (ListOfValues.Keys.Contains(e.RowIndex))
                {
                    ListOfValues[e.RowIndex] = tbl;
                }
                else
                    ListOfValues.Add(e.RowIndex, tbl);
            }
        }
