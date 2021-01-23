    public static void Main(string[] args)
    {
      using (var client = new HttpClient())
      {
        try
        {
          // Next two lines are not required. You can comment or delete that lines without any regrets
          const string baseUri = "{base-url}";
          client.BaseAddress = new Uri(baseUri);
          var content = new FormUrlEncodedContent(new[]
          {
            new KeyValuePair<string, string>("deadId", "3"),
            new KeyValuePair<string, string>("flagValueToSet", "true")
          });
          // response.Result.IsSuccessStatusCode == true and no errors
          var response = client.PostAsync($"{baseUri}/Deals/SetDealFlag?dealId=3&flagValueToSet=true", null); 
          
          // response.Result.IsSuccessStatusCode == false and 404 error
          // var response = client.PostAsync($"{baseUri}/Deals/SetDealFlag", content); 
          response.Wait();
          if (response.Result.IsSuccessStatusCode)
          {
            return;
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          throw;
        }
      }
    }
