    public async Task<List<AllReportVM>> GetAllReports(string token, string username, out string error)
    {
        var httpClient = GetHttpClient();
        if (CrossConnectivity.Current.IsConnected) {
            var response = await httpClient.GetAsync ("getdashboardreports.ashx").ConfigureAwait (false);
            if (response.IsSuccessStatusCode) {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync ().ConfigureAwait (false);
                error = null;
                return JsonConvert.DeserializeObject<List<AllReportVM>> (jsonString);
            } else {
                error = "SystemError";
                return null;
            }
        } else {
            error = "Internet Connectivity Error";
            return null;
        }
    }
