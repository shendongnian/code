        string json = JsonConvert.SerializeObject(monitors, new JsonSerializerSettings 
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        }); 
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return response;
