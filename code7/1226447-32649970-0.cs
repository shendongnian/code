    protected void Page_Load(object sender, EventArgs e)
    {
        List<RolesModel> roleList = new List<RolesModel>();
        roleList = RoleDefinationRelay.GetAllRoles(null);
        //Bind the gridview
        gvRoles.DataSource = roleList;
        gvRoles.DataBind();
    }
