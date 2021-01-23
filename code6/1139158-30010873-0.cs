    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostback)
        {
            PortalEntities db = new PortalEntities();
            var holterQuery = from holt in db.Holters
                              where holt.Id == 1
                              select holt;
            Holter holter = holterQuery.Single();
            string companyName = holter.CompanyName;
            CompanyNameTB.Text = companyName;
        }
    }
