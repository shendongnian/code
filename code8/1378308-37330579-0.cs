    public partial class Personnel_Admin_Teams : System.Web.UI.Page
    {
      DataTable sqlTeamMembers = null;
      DataTable newTeamMembers = null;
      protected void Page_Load( object sender, EventArgs e ) {
        if( !Page.IsPostBack ){
          if( Application.Cache["sqlTeamMembers"] == null ) 
            Application.Cache["sqlTeamMembers"] = new DataTable();
          if( Application.Cache["newTeamMembers"] == null ) 
            Application.Cache["newTeamMembers"] = new DataTable();
        }
        sqlTeamMembers = (DataTable) Application.Cache["sqlTeamMembers"];
        newTeamMembers = (DataTable) Application.Cache["newTeamMembers"];
        gvTeamMembers.DataSource = sqlTeamMembers;
        gvTeamMembers.DataBind();
      }
    }
