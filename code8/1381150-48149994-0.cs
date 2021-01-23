    public async Task<bool> NotifyAsync(string to, string title, string body)
    {
        try
        {
            // Get the server key from FCM console
            var serverKey = string.Format("key={0}", "Your server key - use app config");
            // Get the sender id from FCM console
            var senderId = string.Format("id={0}", "Your sender id - use app config");
            var data = new
            {
                to, // Recipient device token
                notification = new { title, body }
            };
            // Using Newtonsoft.Json
            var jsonBody = JsonConvert.SerializeObject(data);
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
            {
                httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    var result = await httpClient.SendAsync(httpRequest);
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // Use result.StatusCode to handle failure
                        // Your custom error handler here
                        _logger.LogError($"Error sending notification. Status Code: {result.StatusCode}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception thrown in Notify Service: {ex}");
        }
        return false;
    }
