    public static void UpdateTask(string workspaceId, string taskId)
	{
		string json = null;
		byte[] bytes = null;
		string url = string.Format("https://app.asana.com/api/1.0/tasks/{0}", taskId);
		HttpWebRequest req = default(HttpWebRequest);
		Stream reqStream = default(Stream);
		string authInfo = null;
		AsanaUpdateTask TaskData = new AsanaUpdateTask();
		try
		{
			authInfo = BearerToken + Convert.ToString(":");
			/*Required Minimum for a response from API::: workspace, name, and notes*/
			TaskData.workspace = workspaceId; 
			TaskData.name = "Business Collaboration V7";
			TaskData.notes = "1306:: this is working..updated from api Aug 26";
			TaskData.completed = false; //Used to mark task completed
			json = JsonConvert.SerializeObject(TaskData);
			json = Convert.ToString("{ \"data\":") + json + "}";
			bytes = Encoding.UTF8.GetBytes(json);
			req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = WebRequestMethods.Http.Put;
			req.ContentType = "application/json";
			req.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
			req.ContentLength = bytes.Length;
			reqStream = req.GetRequestStream();
			reqStream.Write(bytes, 0, bytes.Length);
			reqStream.Close();
			HttpWebResponse response = (HttpWebResponse)req.GetResponse();
			string res = new StreamReader(response.GetResponseStream()).ReadToEnd();
			Console.WriteLine(res);
			Console.ReadLine();
			string finalString = res.Remove(0, 8);
			finalString = finalString.Remove((finalString.Length - 1));
			var newtask = JsonConvert.DeserializeObject(finalString);
		}
		catch (WebException ex)
		{
			HttpWebResponse response = (HttpWebResponse)ex.Response;
			string readableString = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
		}
	}
