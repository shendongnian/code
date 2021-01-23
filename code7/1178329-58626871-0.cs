    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
    {
          Content = new StringContent("Users doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
          StatusCode = HttpStatusCode.NotFound
     }
     throw new HttpResponseException(response);
