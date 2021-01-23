    protected List<ORM.IBaseModule> LocalModules;
    protected void Page_Load(object sender, EventArgs e)
    {
            var contextItem = Sitecore.Context.Item;
            var service = new SitecoreService(Sitecore.Context.Database.Name);
            LocalModules = new List<ORM.IBaseModule>();
            foreach (Item child in contextItem.Children)
            {
                if (child.TemplateID == ORM.AAAConstraints.TemplateId)
                {
                    LocalModules.Add(service.Cast<ORM.AAA>(child));
                }
                //repeat for each type of child
             }
