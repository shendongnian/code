    public partial class VideoPage : System.Web.UI.Page
    {
        public void getdata()
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Filename from VideoFile", con);
                con.Open();                
                dt.Load(cmd.ExecuteReader());
            }
            VideoRepeater.DataSource = dt;
            VideoRepeater.DataBind();
        }
    }
