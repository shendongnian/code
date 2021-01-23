    public class BaseClient
	{
		protected IRestClient _client = null;
		protected string _urlObj;
		protected string _basePath;
		public BaseClient()
		{
			_client = new RestClient();
		}
		public async Task<Result<IList<T>>> GetList<T>(string path, Dictionary<string, object> parametrs = null)
		{
			var request = new RestRequest(path, Method.GET);
			if (parametrs != null)
			{
				foreach (var keyValue in parametrs)
				{
					request.AddQueryParameter(keyValue.Key, keyValue.Value);
				}
			}
			var response = await _client.Execute<List<T>>(request);
			if (response.IsSuccess)
			{
				return new Result<IList<T>>()
				{
					Success = true,
					Value = response.Data
				};
			}
			else
			{
				var error = new Result<IList<T>>()
				{
					Error = response.StatusCode.ToString(),
					Message = response.StatusDescription,
					Success = false
				};
				return error;
			}
		}
	}
