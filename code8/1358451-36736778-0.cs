    ClientContext context = new ClientContext("SITEURL");
    Site site = context.Site;
    Web web = context.Web;
    context.Load(site);
    context.Load(web);
    context.ExecuteQuery();
