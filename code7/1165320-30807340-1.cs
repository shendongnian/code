     public partial class mydata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var tbl = GetAllfilmperson();
                ListView1.DataSource = tbl;
                ListView1.DataBind();
            }
        }
        // ...
    }
