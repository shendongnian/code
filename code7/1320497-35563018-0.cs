    HttpResponseMessage response = await client.GetAsync("pid=23&lang=en-us");
    if (response.IsSuccessStatusCode)
    {
      //was success
    }
    else
    {
      var statusCode = response.StatusCode;
      //do something with this
    }
