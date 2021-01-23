    private DataTable GetData(SqlCommand cmd)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using(var con = new SqlConnection(strConnString))
        {
             cmd.CommandType = CommandType.Text;
             cmd.Connection = con;
             con.Open();
             DataTable dt = new DataTable();
             //load data into datatable here
             dt.Load(cmd.ExecuteReader());
             return dt;
        }
    }
         
         
