    public partial class Admin : System.Web.UI.Page
    {
        List<String> images = new List();      
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["stuconnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM upload";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               var filep = dr.GetString(1);
               images.add(String.Concat("~/Images/", filep);
            }
            con.Close();
            RptImages.DataSource = images;
            RptImages.DataBind();
        }
    }
