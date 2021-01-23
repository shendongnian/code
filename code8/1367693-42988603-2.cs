    public void ClarifaiTagging(Stream imageStream)
    {
        const string ACCESS_TOKEN = "YOUR_ACCESS_TOKEN";
        const string CLARIFAI_API_URL = "https://api.clarifai.com/v2/models/{model}/outputs";
        
        // Convert the stream to a byte array and convert it to base 64 encoding
        MemoryStream ms = new MemoryStream();
        imageStream.CopyTo(ms);
        string encodedData = Convert.ToBase64String(ms.ToArray());
        using (HttpClient client = new HttpClient())
        {
            // Set the authorization header
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + ACCESS_TOKEN);
            // The JSON to send in the request that contains the encoded image data
            // Read the docs for more information - https://developer.clarifai.com/guide/predict#predict
            HttpContent json = new StringContent(
                "{" +
                    "\"inputs\": [" +
                        "{" +
                            "\"data\": {" +
                                "\"image\": {" +
                                    "\"base64\": \"" + encodedData + "\"" +
                                "}" +
                           "}" +
                        "}" +
                    "]" +
                "}", Encoding.UTF8, "application/json");
            
            // Send the request to Clarifai and get a response
            var response = client.PostAsync(CLARIFAI_API_URL, json).Result;
            
            // Check the status code on the response
            if (!response.IsSuccessStatusCode)
            {
                // End here if there was an error
                return null;
            }
            // Get response body
            string body = response.Content.ReadAsStringAsync().Result.ToString();
            Debug.Write(body);
        }
    }
