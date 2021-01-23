    var tasks = agents.Select(async a =>
            {
                var viewPostRequest = new
                    {
                        AgentId = a.AgentId,
                        itemCode = itemCode,
                        EnvironmentId = environmentTypeId
                    };
                return await client.PostAsJsonAsync("api/postView", viewPostRequest);
            });
		//now tasks is IEnumerable<Task<WebResponse>>
        await Task.WhenAll(tasks);
		//now all the responses are available
        foreach(WebResponse response in tasks.Select(p=> p.Result))
        {
			//do something with the response
		}
