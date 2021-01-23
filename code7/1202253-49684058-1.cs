        public List<YourReturnType> Get(RestRequest request)
        {
			var request = new RestRequest
			{
				Resource = "YourResource",
				RequestFormat = DataFormat.Json,
				Method = Method.POST
			};
			request.AddBody(new YourRequestType());
			var response = Execute<List<YourReturnType>>(request);
            return response.Data;
        }
		public T Execute<T>(RestRequest request) where T : new()
		{
			var client = new RestClient(_baseUrl);
						
			var response = client.Execute<T>(request);
			return response.Data;
		}
