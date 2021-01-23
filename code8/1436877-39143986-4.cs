    if (!Page.IsPostBack)
    {
        if (Session["UserName"] == "admin")
        {
            regiondrop.DataSource = tea.tblReg.Where(x => x.Region == "Factory")
                                       .Select(x => x.Region)
                                       .Distinct()
                                       .ToList();
        }
        else
        {
            regiondrop.DataSource = tea.tblReg.Where(x => x.Region.All(char.IsLetter) && 
                                                          x.Region != "" &&
                                                          x.Region != "Factory")
                                              .Select(x => x.Region)
                                              .Distinct()
                                              .ToList();
        }
        regiondrop.DataTextField = "Region";
        regiondrop.DataValueField = "Region";
        regiondrop.DataBind();
        Label4.Visible = false;
    }
