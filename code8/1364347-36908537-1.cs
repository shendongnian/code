    public class Call : ICall
    {
        private readonly AppSettings appSettings;
        public Call(IOptions<AppSettings> appSettings) 
        {
            this.appSettings = appSetings.Value;
        }
        public Task<HttpResponseMessage>GetHttpResponseMessageFromDeviceAndDataService()
        {
            var client = new HttpClient();
            var uri = new Uri(appSettings.Uri);
            var response =  GetAsyncHttpResponseMessage(client, uri);
            return response;
        }
    }
