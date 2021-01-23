    using (var ctx = new ClientContext(webUri))
    {
         var qry = new CamlQuery();
         qry.ViewXml = "<View Scope='RecursiveAll'>" +
                                  "<Query>" + 
                                      "<Where>" + 
                                            "<Eq>" + 
                                                 "<FieldRef Name='FSObjType' />" + 
                                                 "<Value Type='Integer'>0</Value>" + 
                                            "</Eq>" + 
                                     "</Where>" + 
                                   "</Query>" + 
                                "</View>"; 
        var sourceList = ctx.Web.Lists.GetByTitle(sourceListTitle);
        var items = sourceList.GetItems(qry);
        ctx.Load(items);
        ctx.ExecuteQuery();
        foreach (var item in items)
        {
            //1. ensure target directory exists
            var curPath = targetPath + System.IO.Path.GetDirectoryName((string)item["FileRef"]);
            Directory.CreateDirectory(curPath);
            //2. download a file
            DownloadAFile(item, curPath);   
         }
     }
