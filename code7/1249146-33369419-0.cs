    protected void Page_Load(object sender, EventArgs e)
            {
                // Returns the last month entry from the Past_Places table so can disable the button if it has been run for the current month
                string connection = ConfigurationManager.ConnectionStrings["PaydayLunchConnectionString1"].ConnectionString;
                SqlConnection conn = new SqlConnection(connection);
    
                SqlCommand com = new SqlCommand(
                    "SELECT        TOP (1) Month " +
                    "FROM          Past_Places", conn);
    
                try
                {
                    conn.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        PastMonth.Text = reader["Month"].ToString();
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
