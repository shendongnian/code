        public DataSet tables = new DataSet();
        public OleDbDataAdapter adapter;
        public BusLogic()
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                adapter = new OleDbDataAdapter("SELECT * FROM City", conn);
                adapter.Fill(tables, "Cities");
            }
        }
