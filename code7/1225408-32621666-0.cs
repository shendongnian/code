    static void RunTask(string[] args)
    {
		var templates = new Dictionary<string, string>()
		{
			{ "C:\\test\\first", "A" },
			{ "C:\\test\\second", "B" },
	        { "C:\\test\\third", "C" },
		};
	
		List<PathElement> paths = PathsConfig.GetCurrentPathConfiguration();
		foreach (PathElement folder in paths)//looks at every folder within main folder
		{
			foreach (string file in Directory.EnumerateFiles(folder.Path, "*.csv"))//looks at every file with the extension ".csv" in each folder
			{
				Debug.Write("\n" + file + "\n"); //writes out file names
				using (StreamReader sr = new StreamReader(file))
				{
					String line;
					while ((line = sr.ReadLine()) != null)
					{
						string[] parts = line.Split(',');
						string email = parts[1];
						Debug.Write(email + "\n");//writes out email column
						GetEmailRequest(templates[folder.Path], email);
					}
				}
	
			}
		}
	}
	
	private static List<DM.SendEmailRequest> GetEmailRequest(string templateId, string recipientAddress)
	{
		using (var httpClient = GetHttpClient())
		{
			DM.SendEmailRequest request = new DM.SendEmailRequest();
			request.TemplateId = templateId
			request.RecipientAddress = recipientAddress
	
			var response = GetResponseString(httpClient, "SendEmail", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
	
			return string.IsNullOrWhiteSpace(response) ? default(List<DM.SendEmailRequest>) : JsonConvert.DeserializeObject<List<DM.SendEmailRequest>>(response);
		}
	}
