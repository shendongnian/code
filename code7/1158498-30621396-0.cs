    private async Task<MemberResponse> ProcessResponseAsync(HttpResponseMessage response, HttpClient client)
    {
      using (response)
      {
        if(response.IsSuccessStatusCode)
        {
          var responseText = await response.Content.ReadAsStringAsync();
          var jss = new JavaScriptSerializer();
          var userid = jss.Deserialize<MemberResponse>(responseText);
          return userid;
        }
        else
        { ... }
      }
    }
