    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGvAddEmail();
            }
        }
        private void BindGvAddEmail()
        {
            List<myData> initialData = new List<myData>();
            for (int i = 0; i < int.Parse(ddlNumberOfRow.SelectedValue.ToString()); i++)
            {
                initialData.Add(new myData());
            }
            gvAddEmail.DataSource = initialData;
            gvAddEmail.DataBind();
        }
        protected void ddlNumberOfRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGvAddEmail();
        }
    }
    public class myData
    {
        public string VisitorEmail
        {
            get;
            set;
        }
    }
