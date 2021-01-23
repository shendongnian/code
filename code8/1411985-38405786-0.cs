    string _url = "https://www.googleapis.com/consumersurveys/v2/surveys/";
    client.BaseAddress = new Uri(_url);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ViewBag.GoogleAccessToken);
    using (HttpResponseMessage response = client.GetAsync(MY_API_KEY))
    {
        if (response.IsSuccessStatusCode)
        {
            using (HttpContent content = response.Content)
            {
                var Content = content.ReadAsStringAsync();
                ViewBag.GoogleResponse = Content.ToString();
            }
        }
