    public partial class Personnel_Admin_Teams : System.Web.UI.Page
    {
        DataTable newTeamMembers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //page is loaded for the first time
            {
                newTeamMembers = new DataTable();
            }
        }
        //rest of the code
    }
