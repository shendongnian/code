    public static void DeleteLastUpdate(ClientContext context, Microsoft.SharePoint.Client.List oList)
    {
        // You should not create a context here, but use the supplied context
        // using (var context = new ClientContext(FrontEndAppUrl))
        // {
            var ss = new System.Security.SecureString();
            ...
    }
    public static void GetCountry()
    {
        using (var context = new ClientContext(FrontEndAppUrl))
        {
            Microsoft.SharePoint.Client.List oList_Country = context.Web.Lists.GetByTitle("LISTNAME");
            DeleteLastUpdate(context, oList_Country);  // Pass the context
 
