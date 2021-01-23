	using (var sp = new ClientContext("webUrl"))
	{
		sp.Credentials =  System.Net.CredentialCache.DefaultCredentials;
		var file = sp.Web.GetFileByServerRelativeUrl(filePath);
		sp.Load(file, f => f.Exists);
		file.DeleteObject();
		sp.ExecuteQuery();
		if (!file.Exists)
			throw new System.IO.FileNotFoundException();
	}
