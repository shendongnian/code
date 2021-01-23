    String username = “username”;
    String password = “password”;
        
    String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + “:” + password));
    WebClient.Headers[HttpRequestHeader.Authorization] = “Basic ” + credentials;
