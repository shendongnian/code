    var result = await GetAllReports(token, username)
    if (result is string)
    {
         //Do Something   
    }
    if(result is List<AllReportVM>)
    {
        //Do Something
    }
    public async Task<object> GetAllReports(string token, string username)
    {
        var httpClient = GetHttpClient();
        if (CrossConnectivity.Current.IsConnected) {
            var response = await httpClient.GetAsync ("getdashboardreports.ashx").ConfigureAwait (false);
            if (response.IsSuccessStatusCode) {
                var content = response.Content;
                string jsonString = await content.ReadAsStringAsync ().ConfigureAwait (false);
                return JsonConvert.DeserializeObject<List<AllReportVM>> (jsonString);
            } else {
                return "SystemError";
            }
        } else {
            return "Internet Connectivity Error";
        }
    }
