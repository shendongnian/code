    private static async void TestAsyncPost()
    {
      var values = new Dictionary<string, string>();
      values.Add("regno", "testReg");
      values.Add("phone", "testPhone");
      values.Add("key", "testKey");
      values.Add("secret", "testSecret");
      var content = new FormUrlEncodedContent(values);
      using (var client = new HttpClient())
      {
        try
        {
          var httpResponseMessage = await client.PostAsync("http://theip/registrationsearch/confirm_status.php", content);
          if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
          {
            // Do something...
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            Trace.Write(response);  // response here...
          }
        }
        catch (Exception ex)
        {
          Trace.Write(ex.ToString()); // error here...
        }
      }
    }
