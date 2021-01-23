    ddlProjects.Items.Add(new ListItem("Select a project...",""));
    ddlProjects.AppendDataBoundItems = true;
    ddlProjects.DataSource = dr;
    ddlProjects.DataTextField = "Name";
    ddlProjects.DataValueField = "ProjectID";
    ddlProjects.DataBind();
