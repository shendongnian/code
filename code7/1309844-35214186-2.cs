    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        [WebMethod]
        public static string GetVisitDates(int LookupID, bool isMiscellaneous)
        {
            return string.Format("{0}-{1}", LookupID, isMiscellaneous);
        }
    }
