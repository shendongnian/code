        protected void Page_Load(object sender, EventArts e)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Test"; //your SQL query goes here
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                GridView1.DataSource = table;
                GridView1.DataBind();
                
                cmd.Dispose();
                da.Dispose();
            }
        }
