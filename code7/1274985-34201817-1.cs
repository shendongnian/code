    public partial class _Default : System.Web.UI.Page
    {
        protected int test;
        public Hashtable hashtable = new Hashtable();
        static Hashtable sHashtable = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                sHashtable[1] = "One";
                sHashtable[2] = "Two";
                sHashtable[13] = "Thirteen";
            }
    
        }
        protected void txtKey_TextChanged(object sender, EventArgs e)
        {
            test = Convert.ToInt32("0" + txtKey.Text);
            hashtable = sHashtable;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "GetHashtable", "GetHashtable();", true);
        }
    }
