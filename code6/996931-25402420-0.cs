	public override IEnumerator<WebTestRequest> GetRequestEnumerator()
	{
		for (var i = 0; i < Iterations; ++i)
		{
			var request = new WebTestRequest(_url);
			request.IgnoreHttpStatusCode = true;
            
            ...
			yield return request;
		}
	}
