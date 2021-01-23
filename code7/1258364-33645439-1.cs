    //Add this line
    public  ArrayList Course {get;set;}
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set the course object here
        Course = new ArrayList();     
        const string connectionString = "Data Source=localhost;" + "Initial Catalog=IBBTS_DB; Integrated Security =SSPI";
        const string query = "SELECT X from accelerometerReading";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            using (SqlCommand cm = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader reader = cm.ExecuteReader();
                while (reader.Read())
                {
                    Course.Add(reader.GetDecimal(0));
                }
            }
        }
    }
