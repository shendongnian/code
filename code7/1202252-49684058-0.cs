			var request = new RestRequest
			{
				Resource = "Queries",
				RequestFormat = DataFormat.Json,
				Method = Method.POST
			};
			request.AddBody(new Query());
			var response = RestProxy.Execute<List<Query>>(request);
		public static T Execute<T>(RestRequest request) where T : new()
		{
			var client = new RestClient(_baseUrl);
						
			var response = client.Execute<T>(request);
			return response.Data;
		}
