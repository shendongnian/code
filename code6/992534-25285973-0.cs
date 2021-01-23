    /// <summary>
    /// Download file from a Library 
    /// </summary>
    /// <param name="context">CSOM context</param>
    /// <param name="listTitle">List Title</param>
    /// <param name="listItemId">List Item Id</param>
    /// <param name="downloadPath">Download Path</param>
    private static void DownloadFile(ClientContext context, string listTitle, int listItemId, string downloadPath)
    {
        var list = context.Web.Lists.GetByTitle(listTitle);
        var listItem = list.GetItemById(listItemId);
        context.Load(listItem, i => i.File);
        context.ExecuteQuery();
        var fileRef = listItem.File.ServerRelativeUrl;
        var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, fileRef);
        var fileName = Path.Combine(downloadPath, listItem.File.Name);
        using (var fileStream = System.IO.File.Create(fileName))
        {
            fileInfo.Stream.CopyTo(fileStream);
        }
    }
