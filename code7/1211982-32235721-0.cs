    using (ClientContext ctx = ....))
    {
        Web web = ctx.Web;
        ctx.Load(web);
        ctx.ExecuteQuery();
        Microsoft.SharePoint.Client.File file = web.GetFileByServerRelativeUrl(fileUpload.FullSharepointPath);
    clientContext.Load(file, f => f.CheckOutType, f => f.MajorVersion);
    clientContext.ExecuteQuery();
    }
