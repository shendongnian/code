    if(!IsPostBack)
    {
       using (dbDataContext dt = new dbDataContext())
            {
                var qry = from i in dt.Technologies
                          select i;
    
                ddlTechnology.DataSource = qry;
                ddlTechnology.DataValueField = "TechnologyId";
                ddlTechnology.DataTextField = "TechnologyName";
                ddlTechnology.DataBind();
                ddlTechnology.Items.Insert(0, new ListItem("Select Technology", ""));
            }
    }
