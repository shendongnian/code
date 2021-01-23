    public partial class Reports : System.Web.UI.Page
    {
       private string myquery = string.Emplty; //Try use this
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
           usertype = Session["usertype"].ToString();
            
                if (usertype == "admin")
                {
                    myquery = @"SELECT jobId, odometerReading, jobDescription, status  FROM joborder Where truck_id = '" + truck_id + "'";
                }
                else
                {
                    myquery = @"SELECT jobId, odometerReading, jobDescription, status  FROM joborder Where truck_id = '" + truck_id + "' and status = '1'";
                }
            connectDB();
         }
    }
