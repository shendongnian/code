     public async Task<string> GetResult(){
        using(var httpClient = new HttpClient()){
          var httpResponse = await httpClient.GetAsync(requestMessage);
          var responseContent = await httpResponse.Content.ReadAsStringAsync();
          return responseContent;
    }
    }
