        public CSOM.Folder CreateFolder(CSOM.Web web, string listTitle, string fullFolderPath)
        {
           
            var folderUrls = fullFolderPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
           
            CSOM.List _List = web.Lists.GetByTitle(listTitle);
            web.Context.Load(_List.RootFolder);
            web.Context.ExecuteQuery();
            string listrootfolder = _List.RootFolder.Name.ToString();
            web.Context.Load(web, w => w.ServerRelativeUrl);
            web.Context.ExecuteQuery();
            string root = "";
            for (int i = 0; i < folderUrls.Length; i++)
            {
                root = folderUrls[i].ToString();
                string targetFolderUrl = "/" + listrootfolder + "/" + string.Join("/", folderUrls, 0, i + 1);
                var folder1 = web.GetFolderByServerRelativeUrl(targetFolderUrl);
                web.Context.Load(folder1);
                bool exists = false;
                try
                {
                    web.Context.ExecuteQuery();
                    exists = true;
                }
                catch (Exception ex)
                {
                }
                if (!exists)
                {
                    if (i == 0)
                    {
                        CreateFolderInternal(web, _List.RootFolder, root);
                    }
                    else
                    {
                        web.Context.Load(web, w => w.ServerRelativeUrl);
                        web.Context.ExecuteQuery();
                        var targetfolderUrls = targetFolderUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        string jj = string.Join("/", targetfolderUrls, 0, targetfolderUrls.Length - 1);
                        CSOM.Folder folder = web.GetFolderByServerRelativeUrl(web.ServerRelativeUrl + jj);
                        web.Context.Load(folder);
                        web.Context.ExecuteQuery();
                        SPCreateFolderInternal(web, folder, root);
                    }
                }
                else
                {
                    //already folder exists
                }
            }
            CSOM.Folder finalfolder = web.GetFolderByServerRelativeUrl(web.ServerRelativeUrl + listrootfolder + "/" + fullFolderPath);
            web.Context.Load(finalfolder);
            web.Context.ExecuteQuery();
            return finalfolder;
        }
        private void CreateFolderInternal(CSOM.Web web, CSOM.Folder parentFolder, string fullFolderPath)
        {
            try
            {
                var curFolder = parentFolder.Folders.Add(fullFolderPath);
                web.Context.Load(curFolder);
                web.Context.ExecuteQuery();
            }
            catch (System.Exception ex)
            {               
            }
        }
