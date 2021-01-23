    private async Task ListenAsync()
    {
        while (someCondition)
        {
            string url = "http://www.mywebpage.com?data=my_data";
            string responseBodyAsText = null;
            var response = new HttpResponseMessage();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    response = await httpClient.GetAsync(new Uri(url));
                    responseBodyAsText = await response.Content.ReadAsStringAsync();
                 }
                catch
                {
                    //...
                }
                Debug.WriteLine(responseBodyAsText);
                await Task.Delay(2000);
            }
    }
