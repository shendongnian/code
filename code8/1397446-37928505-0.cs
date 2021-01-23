    ClientContext clientContext = new ClientContext(siteUrl);
    Web site = clientContext.Web;
    List targetList = site.Lists.GetByTitle("My List");
    View targetView = List.Views.GetByTitle("My View");
    targetView.Scope = ViewScope.RecursiveAll;
    targetView.Update();
    clientContext.ExecuteQuery();
