    public static ProfileInfo GET(string url, int profileId)
    {
        try
        {
            // Note this ends in "=" now.
            string basePath = "/widget/api/org-profile/demo-health/npi/?profile-id=";
            string path = basePath + profileId.ToString();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.docscores.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    ProfileInfo info = await response.Content.ReadAsAsync<ProfileInfo>();
                    return info;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
