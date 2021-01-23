    // Create an authentication cookie which we can send with the request so sharepoint knows who we are.
    var authCookie = credentials.GetAuthenticationCookie(new Uri(imageUrl));
    client.Headers.Add(HttpRequestHeader.Cookie, authCookie);
    // Download the image data to a byte array
    image = client.DownloadData(imageUrl);
