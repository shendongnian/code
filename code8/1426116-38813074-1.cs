    public partial class cPage : System.Web.UI.Page
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
    		string cGetValue = ((cMasterPage)Master).getUserName;
        } 
    }
