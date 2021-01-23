    var list = ctx.Web.Lists.GetByTitle(listTitle);
    ctx.Load(list.RootFolder);
    ctx.ExecuteQuery();
               
    var fileName = System.IO.Path.GetFileName(path);
    byte[] data = System.IO.File.ReadAllBytes(path);
    MemoryStream stream = new MemoryStream(data);    
    var fileUrl = Path.Combine(list.RootFolder.ServerRelativeUrl, fileName);
    if (ctx.HasPendingRequest)
         ctx.ExecuteQuery();
    Microsoft.SharePoint.Client.File.SaveBinaryDirect(ctx, fileUrl, stream, true); 
 
