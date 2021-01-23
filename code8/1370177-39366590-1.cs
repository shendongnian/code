    [HttpGet]
    public async Task<HttpResponseMessage> GetDocumentById(string id)
    {
        var documentUri = UriFactory.CreateDocumentUri(database.Id, collection.Id, id);
        var resourceResponse = await _client.ReadDocumentAsync(documentUri);
        resourceResponse.ResponseStream.Position = 0;
        using (StreamReader reader = new StreamReader(resourceResponse.ResponseStream, Encoding.UTF8))
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(reader.ReadToEnd(), Encoding.UTF8, "application/json");
            return response;
        }
    }
