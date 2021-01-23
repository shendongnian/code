        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string connString = "Dsn=IFMX32;uid=informix";
                string cmd = "select * from syschfree";
                OdbcConnection conn = new OdbcConnection(connString);
                OdbcDataAdapter adapter = new OdbcDataAdapter(cmd, conn);
                conn.Open();
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
