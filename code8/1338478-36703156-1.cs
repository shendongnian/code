	using (var ctx = TokenHelper.GetClientContextWithAccessToken(ConfigurationManager.AppSettings("url"), TokenHelper.GetAppOnlyAccessToken(TokenHelper.SharePointPrincipal, siteUri.Authority, realm).AccessToken) )
	{                
		var web = ctx.Web;
		Microsoft.SharePoint.Client.File file = web.GetFileByServerRelativeUrl(fromLocation);
		ctx.Load(file);
		ctx.ExecuteQuery();
		
		HttpContext.Current.Response.ContentType = MimeMapping.GetMimeMapping(file.Name);
		HttpContext.Current.Response.AppendHeader("content-disposition", "inline;filename=" + file.Name);
		HttpContext.Current.Response.BinaryWrite(StreamToByteArray(data.Value));
		HttpContext.Current.Response.Flush();
	}
	
    private byte[] StreamToByteArray(ByVal input As Stream)
	{
        byte[] buffer = new byte[16 * 1024];
		
		using (MemoryStream ms = new MemoryStream())
		{ 
			int read; 
			while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
			{ 
				ms.Write(buffer, 0, read);
			} 
			return ms.ToArray();
		} 
    }
