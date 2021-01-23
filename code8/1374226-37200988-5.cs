    public class RequestResult<T>
    {
        public bool Success { get; }
        public T Result { get; }
        public string ErrorMessage { get; }
        private RequestResult(bool success, T result, string errorMessage)
        {
            this.Success = success;
            this.Result = result;
            this.ErrorMessage = errorMessage;
        }
        public static RequestResult<T> Success(T result)
        {
            return new RequestResult<T>(true, result, null);
        }
        public static RequestResult<T> Failure(string errorMessage)
        {
            return new RequestResult<T>(false, default(T), errorMessage);
        }
    }
    public async Task<RequestResult<List<AllReportVM>>> GetAllReports(string token, string username)
    {
        var httpClient = GetHttpClient();
        if (CrossConnectivity.Current.IsConnected) {
            var response = await httpClient.GetAsync ("getdashboardreports.ashx").ConfigureAwait (false);
            if (response.IsSuccessStatusCode) {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync ().ConfigureAwait (false);
                var result = JsonConvert.DeserializeObject<List<AllReportVM>> (jsonString);
                return RequestResult.Success(result);
            } else {
                return RequestResult.Failure("SystemError");
            }
        } else {
            return RequestResult.Failure("Internet Connectivity Error");
        }
    }
