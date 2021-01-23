        public partial class ListUsers : System.Web.UI.Page
        {
        // the object is declared here.
        // I understand it should be valid even if the page loads again
        CurrentUserStructure currentuserinfo = new CurrentUserStructure();
    
        private List<CurrentUserStructure.ListUserClass> ListOfUsers
        {
           get { 
                  return Session["CurrentNamespace.ListOfUsers"] ?? new List<CurrentUserStructure.ListUserClass>()
               }
           set {
                    Session["CurrentNamespace.ListOfUsers"] = value;
               }
        }
    
    
         
        protected void Page_Load(object sender, EventArgs e)
        {
            // everything from here on should happen only
            // the first time the page is loaded
            if (!IsPostBack)
            {
                // bellow the lsUser object is constructed
                this.ListOfUsers = currentuserinfo.GetUserList();
            }   // up to here the lsUsers object is available
    } 
 
