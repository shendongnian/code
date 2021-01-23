    public partial class worker : System.Web.UI.MasterPage
    {
        public IDbConnection Con {get; private set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ViewEta"].ConnectionString);
        }
    }
