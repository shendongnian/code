        using (ClientContext context = new ClientContext(sp_site_address))
        {
                context.AuthenticationMode = ClientAuthenticationMode.FormsAuthentication;
                context.FormsAuthenticationLoginInfo = new FormsAuthenticationLoginInfo(username, pwd);
                List list = context.Web.Lists.GetByTitle(requests_list_name);
                CamlQuery query = new CamlQuery();
                query.ViewXml = "<View><RowLimit>100</RowLimit></View>";
                ListItemCollection items = list.GetItems(query);
                context.Load(items);
                context.ExecuteQuery();
                foreach (ListItem oListItem in items)
                {
                    FileCollection files = GetAttachments(context, list, oListItem);
                    foreach (Microsoft.SharePoint.Client.File f in files)
                    {
                        Download(f.ServerRelativeUrl, FolderToSaveTo, context, f.Name);
                    }
                    lstRequests.Add(Agreement);
                }
            }
        }
        public static FileCollection GetAttachments(ClientContext ctx, List list, ListItem item)
        {
            ctx.Load(list, l => l.RootFolder.ServerRelativeUrl);
            ctx.Load(ctx.Site, s => s.Url);
            ctx.ExecuteQuery();
            Folder attFolder = ctx.Web.GetFolderByServerRelativeUrl(list.RootFolder.ServerRelativeUrl + "/Attachments/" + item.Id);
            FileCollection files = attFolder.Files;
            ctx.Load(files, fs => fs.Include(f => f.ServerRelativeUrl, f => f.Name, f => f.ServerRelativeUrl));
            ctx.ExecuteQuery();
            return files;
        }
        public static void Download(string serverFilePath, string destPath, ClientContext context, string filename)
        {
            using (FileInformation ffl = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, serverFilePath))
            {
                if (System.IO.Directory.Exists(destPath))
                {
                    using (FileStream fileStream = System.IO.File.Create(destPath + "\\" + filename))
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            ffl.Stream.CopyTo(stream);
                            stream.WriteTo(fileStream);
                        }
                    }
                }
            }
        }
