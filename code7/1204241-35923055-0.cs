    private void subscribeAddress() 
    {
	  string apiKey = "APIKEY-usX"; //your API KEY created by you.
	  string dataCenter = "usX";
	  string listID = "listID"; //The ListID of the list you want to use.
	  SubscribeClassCreatedByMe subscribeRequest = new SubscribeClassCreatedByMe 
	  {
		  email_address = "somebodys@email.com",
		  status = "subscribed"
	  };
	  subscribeRequest.merge_fields = new MergeFieldClassCreatedByMe();
	  subscribeRequest.merge_fields.FNAME = "YourName";
	  subscribeRequest.merge_fields.LNAME = "YourSurname";
	  using (HttpClient client = new HttpClient())
	  {
		  var uri = "https://" + dataCenter + ".api.mailchimp.com/";
		  var endpoint = "3.0/lists/" + listID + "/members";
		  client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", apiKey);
		  client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		  client.BaseAddress = new Uri(uri);
		  //NOTE: To avoid the method being 'async' we access to '.Result'
		  HttpResponseMessage response = client.PostAsJsonAsync(endpoint, subscribeRequest).Result;//PostAsJsonAsync method serializes an object to 
																								//JSON and then sends the JSON payload in a POST request
		//StatusCode == 200
		// -> Status == "subscribed" -> Is on the list now
		// -> Status == "unsubscribed" -> this address used to be on the list, but is not anymore
		// -> Status == "pending" -> This address requested to be added with double-opt-in but hasn't confirmed yet
		// -> Status == "cleaned" -> This address bounced and has been removed from the list
		//StatusCode == 404
		if ((response.IsSuccessStatusCode))
		{
           //Your code here
		}
	  }
    }
