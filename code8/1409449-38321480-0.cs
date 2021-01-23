    public class Activity
    {
        public int RowID { get; set; }
        public DateTime Created { get; set; }
        public string FirstName { get; set; }
    }
    public partial class UsingSqlDataReader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.GetData();
            }
        }
        private void GetData()
        {
            string cs = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            var activities = new List<Activity>();
            using (var con = new SqlConnection(cs))
            {
                using(var cmd = new SqlCommand("SELECT ACT.ROW_ID,ACT.CREATED,ACT.FIRST_NAME FROM [dbo].[S_ACTIVITY] ACT", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var activity = new Activity();
                            activity.RowID = Convert.ToInt32(reader["ROW_ID"]);
                            activity.Created = DateTime.Parse(reader["CREATED"].ToString());
                            activity.FirstName = Convert.ToString(reader["FIRST_NAME"]);
                            activities.Add(activity);
                        }
                    }
                }
            }
            GridView1.DataSource = activities;
            GridView1.DataBind();
        }
    }
