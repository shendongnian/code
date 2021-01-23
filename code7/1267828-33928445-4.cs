        public string sqlCon ="data source=(local);Initial Catalog=XXX;Integrated Security=True";
        public SqlCommand Cmd;
        public SqlConnection Conn;
        public SqlDataReader Drdr;
        public Form1()
        {
            InitializeComponent();
            this.Conn = new SqlConnection(this.sqlCon);
            this.Cmd = new SqlCommand("select * from [tblTestBC]", this.Conn);
            useBulkCopy();
        }
        void justread()
        {
            this.Cmd.Connection.Open();
            this.Drdr = this.Cmd.ExecuteReader();
            if (this.Drdr.HasRows)
                while (this.Drdr.Read())
                {
                }
            this.Cmd.Connection.Close();
        }
        void useBulkCopy()
        {
            var bulkCopy = new SqlBulkCopy(this.Cmd.Connection);
            bulkCopy.DestinationTableName = "tblTestBC";
            //bulkCopy.ColumnMappings.Add("age", "age");
            //bulkCopy.ColumnMappings.Add("name", "name");
            this.Cmd.Connection.Open();
            try
            {
                using (var dataReader = new mySimpleDataReader())
                {
                    bulkCopy.WriteToServer(dataReader);
                }
                this.Cmd.Connection.Close();
            }
            catch (Exception e)
            {
            }
        }
