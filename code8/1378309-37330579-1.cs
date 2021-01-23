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
        // NOTE: sqlTeamMembers will be null until you make that call to 
        //       populateTeamMembers()  so there is no hard and fast rule 
        //       about binding during PageLoad.  Bind every time you need 
        //       to reflect changes.
        gvTeamMembers.DataSource = sqlTeamMembers;
        gvTeamMembers.DataBind();
      }
    }
