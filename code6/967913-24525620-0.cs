    public class Connection
    {       
        SqlConnection con;
        
        public SqlConnection Conn { get { return con; } }
        public void OpenCnn()
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["myconnstrng"].ToString();
            con = new SqlConnection(cnnStr);
            con.Open();
        }
        public void CloseCnn()
        {
            con.Close();
        }
    }
