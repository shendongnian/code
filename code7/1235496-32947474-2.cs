        public FileInformation GetFileFromAttachment(int itemId, string filename)
        {
            FileInformation file = null;
            //continue here
            if (new FileInfo(filename).Name != null)
            {
                CSOMUtils.ExecuteInNewContext(QueryConfig.siteUrl, delegate(ClientContext clientContext)
                {
                    clientContext.Credentials = QueryConfig.credentials;
                    clientContext.Load(clientContext.Web, l => l.ServerRelativeUrl);
                    clientContext.ExecuteQuery();
                    List oList = clientContext.Web.Lists.GetByTitle(ListName);
                    clientContext.ExecuteQuery();
                    string url = string.Format("{0}/Lists/{1}/Attachments/{2}/{3}",
                        clientContext.Web.ServerRelativeUrl,
                        ListName,
                        itemId,
                        filename);
                    var f = clientContext.Web.GetFileByServerRelativeUrl(url);
                    clientContext.Load(f);
                    clientContext.ExecuteQuery();
                    file = File.OpenBinaryDirect(clientContext, f.ServerRelativeUrl);
                });
            }
            return file;
        }
