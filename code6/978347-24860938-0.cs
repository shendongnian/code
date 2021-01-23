    public   string connStr = "Provider=SQLOLEDB;Data Source=.;Initial  Catalog=<dbName>;Integrated Security=SSPI";
      public OleDbConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Test();
        }
        public void Test()
        {
            con = new OleDbConnection(connStr);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from tblApartments", con);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
        }
