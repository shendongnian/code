            var client = new HttpClient();
            var content = new MultipartFormDataContent();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Utils.GetAccessTokenFromFile());
            content.Add(new StreamContent(File.Open(Utils.AnyFilePath, FileMode.Open)), "token", "test.txt");
            content.Add(new StringContent("{\"name\":\"test.txt\", \"parent\":{\"id\":\"0\"}}"), "attributes");
            var result = await client.PostAsync("https://upload.box.com/api/2.0/files/content", content);
            result.EnsureSuccessStatusCode();
            string sContent = await result.Content.ReadAsStringAsync();
