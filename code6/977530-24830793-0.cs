    public string strRegStud;
    private void frm2_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\dbname.mdb;");
                OleDbCommand command = new OleDbCommand();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                Con.Open();
                command.CommandText = String.Format("SELECT * FROM book_issued WHERE regid ='{0}'", strRegStud);;
                command.Connection = Con;
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                Con.Close();
                Con.Dispose();
                datagridview1.DataSource = dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
