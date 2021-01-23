    async Task<List<User>> GetUsersAsync()
    {
        List<User> users = new List<User>();
        using (var client = new HttpClient())
        {
             //... Code to get the token ...
            var token = "myToken";
            client.BaseAddress = new Uri("http://localhost:56057/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await client.GetAsync("api/users/");
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
        }
        return users;
    }
