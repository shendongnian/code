    HttpResponseMessage response = await client.GetAsync("pid=23&lang=en-us");
    if (response.IsSuccessStatusCode)
    {
        //was success
        var result = await response.Content.ReadAsStringAsync();     
        //checck result string now
       //you can also deserialize the response to your custom type if needed.
    }
    else
    {
      var statusCode = response.StatusCode;
      //do something with this
    }
