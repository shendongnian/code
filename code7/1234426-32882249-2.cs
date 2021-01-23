    var uri = "http://google.com.com";
            
    var client = new HttpClient();
    try
    {
       var values = new List<KeyValuePair<string, string>>();
       // add values to data for post
       values.Add(new KeyValuePair<string, string>("FirstName", "KRITZTE"));
       FormUrlEncodedContent content = new FormUrlEncodedContent(values);
       // Post data
       var result = client.PostAsync(uri, content).Result;
       // Access content as stream which you can read into some string
       Console.WriteLine(result.Content);
       // Access the result status code
       Console.WriteLine(result.StatusCode);
    }
    catch(AggregateException ex)
    {
        // get all possible exceptions which are thrown
        foreach (var item in ex.Flatten().InnerExceptions)
        {
            Console.WriteLine(item.Message);
        }
    }
