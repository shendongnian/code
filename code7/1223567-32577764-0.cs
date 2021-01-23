    public static void CopyDocuments(string srcUrl, string destUrl, string srcLibrary, string destLibrary, Login _login)
    {
        // set up the src client
        SP.ClientContext srcContext = new SP.ClientContext(srcUrl);
        srcContext.AuthenticationMode = SP.ClientAuthenticationMode.FormsAuthentication;
        srcContext.FormsAuthenticationLoginInfo = new SP.FormsAuthenticationLoginInfo(_login.UserName, _login.Password);
        // set up the destination context (in your case there is no needs to create a new context, because it would be the same library!!!!)
        SP.ClientContext destContext = new SP.ClientContext(destUrl);
        destContext.AuthenticationMode = SP.ClientAuthenticationMode.FormsAuthentication;
        destContext.FormsAuthenticationLoginInfo = new SP.FormsAuthenticationLoginInfo(_login.UserName, _login.Password);
        // get the list and items
        SP.Web srcWeb = srcContext.Web;
        SP.List srcList = srcWeb.Lists.GetByTitle(srcLibrary);
        SP.ListItemCollection col = srcList.GetItems(new SP.CamlQuery());
        srcContext.Load(col);
        srcContext.ExecuteQuery();
        // get the new list
        SP.Web destWeb = destContext.Web;
        destContext.Load(destWeb);
        destContext.ExecuteQuery();
        foreach (var doc in col)
        {
            try
            {
                if (doc.FileSystemObjectType == SP.FileSystemObjectType.File)
                {
                    // get the file
                    SP.File f = doc.File;
                    srcContext.Load(f);
                    srcContext.ExecuteQuery();
                    // build new location url
                    string nLocation = destWeb.ServerRelativeUrl.TrimEnd('/') + "/" + destLibrary.Replace(" ", "") + "/" + f.Name;
                    // read the file, copy the content to new file at new location
                    SP.FileInformation fileInfo = SP.File.OpenBinaryDirect(srcContext, f.ServerRelativeUrl);
                    SP.File.SaveBinaryDirect(destContext, nLocation, fileInfo.Stream, true);
                } 
                if (doc.FileSystemObjectType == SP.FileSystemObjectType.Folder)
                {
                    // load the folder
                    srcContext.Load(doc);
                    srcContext.ExecuteQuery();
                    // get the folder data, get the file collection in the folder
                    SP.Folder folder = srcWeb.GetFolderByServerRelativeUrl(doc.FieldValues["FileRef"].ToString());
                    SP.FileCollection fileCol = folder.Files;
                    // load everyting so we can access it
                    srcContext.Load(folder);
                    srcContext.Load(fileCol);
                    srcContext.ExecuteQuery();
                    foreach (SP.File f in fileCol)
                    {
                        // load the file
                        srcContext.Load(f);
                        srcContext.ExecuteQuery();
                        string[] parts = null;
                        string id = null;
                        if (srcLibrary == "My Files")
                        {
                            // these are doc sets
                            parts = f.ServerRelativeUrl.Split('/');
                            id = parts[parts.Length - 2];
                        }
                        else
                        {
                            id = folder.Name;
                        }
                        // build new location url
                        string nLocation = destWeb.ServerRelativeUrl.TrimEnd('/') + "/" + destLibrary.Replace(" ", "") + "/" + id + "/" + f.Name;
                        // read the file, copy the content to new file at new location
                        SP.FileInformation fileInfo = SP.File.OpenBinaryDirect(srcContext, f.ServerRelativeUrl);
                        SP.File.SaveBinaryDirect(destContext, nLocation, fileInfo.Stream, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Log("File Error = " + ex.ToString());
            }
        }
    }
