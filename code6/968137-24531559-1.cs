    if (Session["AllUsers"] == null)
    {
        LoadDataForUser();
    }
    
    var lstUser = (List<Entities.User>)Session["AllUsers"];
    
    ddlEmployees.DataTextField = "UserName";//I am getting Error here
    ddlEmployees.DataValueField = "UserID";
    ddlEmployees.DataSource = from user in lstUser
                               select new { user.UserID, UserName = user.UserDetail.Name };
    ddlEmployees.DataBind();
    
    ListItem li = new ListItem("--Select Users--", "-1");
    ddlEmployees.Items.Insert(0, li);
