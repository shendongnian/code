	using (var sp = new ClientContext("webUrl"))
	{
		sp.Credentials =  System.Net.CredentialCache.DefaultCredentials;
		sp.Web.GetFileByServerRelativeUrl(filePath).DeleteObject();
		sp.ExecuteQuery();
	}
