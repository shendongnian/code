    [Route("resource")]
    public async Task<dynamic> CreateResource([FromBody]Resource resource)
    {
        if (resource == null) return BadRequest();
        dynamic response = null;
        resource.Topic = GetDataFromSomewhereElse();
        var message = new PostMessage(resource).BodyContent;
        dynamic postRequest = new
        {
            Message = message
        };
        var post = JsonConvert.SerializeObject(postRequest);
            
        HttpContent content = new StringContent(post, Encoding.UTF8, "application/json");
        using (var client = new HttpClient())
        {
            client.Timeout = TimeSpan.FromMinutes(1);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            try
            {
                client.BaseAddress = @"http://localhost:51145/"; 
                HttpResponseMessage postResponse = await client.PostAsync("Resource", content); //"Resource" is a route exposed on the remote host
                    
                string json = await postResponse.Content.ReadAsStringAsync();
                return json;
                    
                if (postResponse.StatusCode == HttpStatusCode.BadRequest) return BadRequest();
                if (postResponse.StatusCode == HttpStatusCode.InternalServerError) return InternalServerError();
                if (postResponse.StatusCode == HttpStatusCode.NotFound) return NotFound();
                return NotFound();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
