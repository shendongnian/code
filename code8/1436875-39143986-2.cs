    if (!Page.IsPostBack)
    {
        if (Session["UserName"] == "admin")
        {
            regiondrop.DataSource = tea.tblReg.Where(x => x.Region == "Factory")
                                       .Select(x => new { Region = x.Region, Value = x.Region })
                                       .ToList();
        }
        else
        {
            regiondrop.DataSource = tea.tblReg
               .Where(x => x.Region.All(char.IsLetter) && x.Region != "")
               .GroupBy(x => x.Region)
               .Select(x => new { Region = x.Key, Value = x.Key })
               .ToList();
        }
        regiondrop.DataTextField = "Region";
        regiondrop.DataValueField = "Region";
        regiondrop.DataBind();
        Label4.Visible = false;
    }
