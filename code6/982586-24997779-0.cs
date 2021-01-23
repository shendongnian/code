    private async void Function() 
    {
         var client = new RestSharp.RestClient("https://exampleapi.com");
         client.Authenticator = [....]
         var request =  new RestSharp.RestRequest("/example.json", Method.GET);
         try
         {
             var response = await client.ExecuteTaskAsync(request);
    
             if (reponse.StatusCode == HttpStatusCode.OK)
             {
                 // Operations with the json...
             }
             else
             {
                 MessageBox.Show("Error");
             }
         }
         catch (Exception error)
         {
             MessageBox.Show(error.Message);
         }
      }
