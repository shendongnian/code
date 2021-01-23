    var downloadTasksQuery = listOfPostData.Select(async postData =>
        {
            var content = new FormUrlEncodedContent(postData);
            HttpResponseMessage response = await client.PostAsync("/Token", content).Result; ;                                 
            var responseBodyAsText = response.Content.ReadAsStringAsync();
            return responseBodyAsText;               
        });
