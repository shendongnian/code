    using (var httpClient = new HttpClient())
    {
        try
        {
            var response = await httpClient.GetAsync(url);
    
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ObjectThatRepresentsYourJson objectThatRepresentsYourJson = JsonConvert.DeserializeObject<ObjectThatRepresentsYourJson>(responseContent);
            }
        }
    }
