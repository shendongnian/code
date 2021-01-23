     protected void Page_Load(object sender, EventArgs e)
     {
    	if(!Page.IsPostBack){
    		List<RolesModel> roleList = new List<RolesModel>();
    		roleList = RoleDefinationRelay.GetAllRoles(null);
    		//set data source of repeater and bind
    		 rptRoles.DataSource = roleList;
    		 rptRoles.DataBind();
    	}
    
     }
