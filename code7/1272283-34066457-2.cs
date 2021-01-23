    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var result = await GetDownloadsAsync();
            string jsonstring = result;
        }
        private async Task<string> GetDownloadsAsync()
        {
            JsonObject jsonObject = new JsonObject
            {
                {"StudentID", JsonValue.CreateStringValue(user.Student_Id.ToString()) },
            };
            string ServiceURI = "http://m.xxx.com/xxxx.svc/GetDownloadedNotes";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ServiceURI);
            request.Content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string returnString = await response.Content.ReadAsStringAsync();
            return returnString;
        }
    }
