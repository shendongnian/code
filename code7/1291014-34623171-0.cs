    public partial class Exercise1 : System.Web.UI.Page
    {
        private RaceResult UserClick;
       //public int Clicks = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // First page load?
            if(!IsPostBack)
            {
                 UserClick = new RaceResult(0);          
                 UserClick.NbrClicksReached += User_Click_NbrClicksReached;
                 Session["UserClick"] = UserClick;
            }
            else
            {
               // Get from first load
               UserClick = Session["UserClick"];
               if(UserClick == null)
               {
                 UserClick = new RaceResult(0);          
                 UserClick.NbrClicksReached += User_Click_NbrClicksReached;
                 Session["UserClick"] = UserClick;
               }
            }
        }
