	public static Task RunAsync()
	{
		string pathValue = WebConfigurationManager.AppSettings["R2G2APIUrl"];
		var client = new HttpClient()
                client.BaseAddress = new Uri(pathValue);
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json"));
                var id = "12421";
	        return client.GetAsync("api/products/1").ContinueWith(_ =>
		{
		    var jobid = new Jobs() { Job_ID = id };
		    return client.PostAsJsonAsync("api/products", jobid)
		   .ContinueWith(responseTask =>
		    {
			  var gizmoUrl = responseTask.Result.IsSuccessStatusCode ?
											responseTask.Result.Headers.Location : null;
		    });
		});
	}
	
