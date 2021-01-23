    const string ThumbUrl = "https://graph.windows.net/myorganization/users/{0}/thumbnailPhoto?api-version=1.6";
    // Attempts to retrieve the thumbnail image for the specified user, with fallback.
    // Returns: Fully formatted string for supplying as the src attribute value of an img tag.
    private string GetUserThumbnail(string userId)
    {
        string thumbnail = "some base64 encoded fallback image";
        string mediaType = "image/jpg"; // whatever your fallback image type is
        string requestUrl = string.Format(ThumbUrl, userId);
  
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
        HttpResponseMessage response = client.GetAsync(requestUrl).Result;
        
        if (response.IsSuccessStatusCode)
        {
            // Read the response as a byte array
            var responseBody = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
        
            // The headers will contain information on the image type returned
            mediaType = response.Content.Headers.ContentType.MediaType;
        
            // Encode the image string
            thumbnail = Convert.ToBase64String(responseBody);
        }
   
        return $"data&colon;{mediaType};base64,{thumbnail}";
    }
    // Factored out for use with other calls which may need the token
    private string GetToken()
    {
        return HttpContext.Current.Session["Token"] == null ? string.Empty : HttpContext.Current.Session["Token"].ToString();
    }
    
