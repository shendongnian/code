    public async Task<List<AllReportVM>> GetAllReports(string token, string username)
    {
        var httpClient = GetHttpClient();
        if (CrossConnectivity.Current.IsConnected) {
            var response = await httpClient.GetAsync ("getdashboardreports.ashx").ConfigureAwait (false);
            if (response.IsSuccessStatusCode) {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync ().ConfigureAwait (false);
                return JsonConvert.DeserializeObject<List<AllReportVM>> (jsonString);
            } else {
                throw new Exception("SystemError");
            }
        } else {
            throw new Exception("Internet Connectivity Error");
        }
    }
