    var apiKey = "<api-key>";
    var listId = "<your-list-id>";
    var email = "<email-address-to-add>";
    using (var wc = new System.Net.WebClient())
    {
        // Data to be posted to add email address to list
        var data = new { email_address = email, status = "subscribed" };
        // Serialize to JSON using Json.Net
        var json = JsonConvert.SerializeObject(data);
	
        // Base URL to MailChimp API
        string apiUrl = "https://us12.api.mailchimp.com/3.0/";
        // Construct URL to API endpoint being used
        var url = string.Concat(apiUrl, "lists/", listId, "/members");
        // Set content type
        wc.Headers.Add("Content-Type", "application/json");
        // Generate authorization header
        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(":" + apiKey));
        // Set authorization header
        wc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
        // Post and get JSON response
        string result = wc.UploadString(url, json);
    }
