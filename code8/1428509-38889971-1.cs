            ParentFolder.Context.Load(ParentFolder);
            ParentFolder.Context.Load(ParentFolder.Folders);
            ParentFolder.Context.Load(ParentFolder.Files);
            ParentFolder.Context.Load(ParentFolder.Files, items => items.Include(item => item.ServerRelativePath));
            ParentFolder.Context.ExecuteQuery();
            if (Applicable business logic){
                foreach (Microsoft.SharePoint.Client.File xFile in ParentFolder.Files){
                    FileCounter++;
                    Console.WriteLine(xFile.Name + "  (" + xFile.ServerRelativePath.DecodedUrl + ")");
                    xFile.Context.Load(xFile.ListItemAllFields);
                    xFile.Context.Load(xFile.ModifiedBy);
                    xFile.Context.ExecuteQuery();
                    More business logic code relating to the file itself...
            }  //end if statement
         }  // end foreach loop
