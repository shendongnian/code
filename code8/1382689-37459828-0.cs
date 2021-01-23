    try
    {
      response = await http.GetAsync(url);
      if(response.IsSuccessStatusCode)
      {
             //handle success
      }
      else
      {
            //handle failure   
      }
    }
    finally
    {
      http.Dispose();
    }
