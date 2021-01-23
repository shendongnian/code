    public Stream GetFile() 
        { 
            using (ClientContext clientContext = GetContextObject()) 
            { 
 
                Web web = clientContext.Web; 
                clientContext.Load(web, website => website.ServerRelativeUrl); 
                clientContext.ExecuteQuery(); 
                Regex regex = new Regex(SiteUrl, RegexOptions.IgnoreCase); 
                string strSiteRelavtiveURL = regex.Replace(FileUrl, string.Empty); 
                string strServerRelativeURL = CombineUrl(web.ServerRelativeUrl, strSiteRelavtiveURL); 
 
                Microsoft.SharePoint.Client.File oFile = web.GetFileByServerRelativeUrl(strServerRelativeURL); 
                clientContext.Load(oFile); 
                ClientResult<Stream> stream = oFile.OpenBinaryStream(); 
                clientContext.ExecuteQuery(); 
                return this.ReadFully(stream.Value); 
            } 
        } 
