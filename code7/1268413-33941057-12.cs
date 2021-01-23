    public async void ProcessReplicationItem(ReplicationItem replicationItem)
    {
        using (var db = new MyDbContext())
        {
            // Custom method that attempts to get remote value by Model Name and Id
			// This is where I get the strongly typed object 
            var remoteRecord = await TryGetAsync(replicationItem.ModelName, replicationItem.Id);
            bool hasRemoteRecord = remoteRecord.Content != null;
            // Get to know if a local copy of this record exists.
            bool hasLocalRecord = db.HasRecord_ReflectionTest(replicationItem.ModelName, replicationItem.Id);
            // Ensure response is valid whether it is a successful get or error is meaningful ( ie. NotFound )
            if (remoteRecord.Success || remoteRecord.ResponseCode == System.Net.HttpStatusCode.NotFound)
            {
                switch (replicationItem.Action)
                {
                    case ReplicationAction.Create:
                    {
                        if (hasRemoteRecord)
                        {
                            if (hasLocalRecord)
                                await db.UpdateDynamic(remoteRecord.Content);
                            else
                                await db.InsertDynamic(remoteRecord.Content);
                        }
                        // else - Do nothing
                        break;
                    }
                    case ReplicationAction.Update:
                        [etc...]
                }
            }
        }
    }
	
	// Get record from server and with 'response.Content.ReadAsAsync' type it 
	// already to the appropriately
	public static async Task<Response> TryGetAsync(ReplicationItem item)
	{
		if (string.IsNullOrWhiteSpace(item.ModelName))
		{
			throw new ArgumentException("Missing a model name", nameof(item));
		}
		if (item.Id == Guid.Empty)
		{
			throw new ArgumentException("Missing a primary key", nameof(item));
		}
		// This black box, just extrapolate a uri based on model name and id
		// typically "api/ModelA/{the-guid}"
		string uri = GetPathFromMessage(item);
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri("http://localhost:12345");
			HttpResponseMessage response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				return new Response()
				{
					Content = await response.Content.ReadAsAsync(Type.GetType(item.ModelName)),
					Success = true,
					ResponseCode = response.StatusCode
				};
			}
			else
			{
				return new Response()
				{
					Success = false,
					ResponseCode = response.StatusCode
				};
			}
		}
	}
	
	public class Response
    {
        public object Content { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
    }
