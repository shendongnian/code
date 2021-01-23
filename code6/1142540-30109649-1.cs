    [HttpGet]
    public async Task<IHttpActionResult> Get(int id) {
          using(HttpClient client = new HttpClient()) {
               var getRequest = client.GetAsync(apiUrl);
               // Do stuff while you wait for response (Or you can do nothing)
               HttpResponseMessage response = await getRequest;
               return ResponseMessage(response);
          }
    }
