    using (var ctx = new ClientContext(webUri))
    {
         var targetList = ctx.Web.Lists.GetByTitle("Documents");
         var fileInfo = new FileCreationInformation
         {
              Url = System.IO.Path.GetFileName(sourcePath),
              Content = System.IO.File.ReadAllBytes(sourcePath),
              Overwrite = true
         };
         var file = targetList.RootFolder.Files.Add(fileInfo);
         var item = file.ListItemAllFields;
         item["Category"] = "User Guide";
         item.Update();
         ctx.ExecuteQuery();
    }  
