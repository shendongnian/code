    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Request.QueryString["param"];
            if (q != null)
            {
                Response.Write("param is ");
                Response.Write(q);
            }
        }
    }
    
