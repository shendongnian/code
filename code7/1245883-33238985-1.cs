    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Session["LagdaFargerItems"] != null)
        { 
            ListItemCollection lic = (ListItemCollection)Session["LagdaFargerItems"];
            foreach(ListItem li in lic)
                lstLagdaFarger.Items.Add(li); // your other ListBox on page2
        }
    }
