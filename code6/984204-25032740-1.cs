      protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                GridView1.DataSource = GetData("SELECT JobNo, JobStage, JobStatus FROM YourTABLE GROUP BY JobNo, JobStage, JobStatus");
        
                GridView1.DataBind();
            }
        }
    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
    
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
