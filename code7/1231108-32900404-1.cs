    string userName;
    string password;
    string authorizationString = userName + ":" + password;
    string encodedValue = Convert.ToBase64String(Encoding.ASCII.GetBytes(authorizationString));
    string authorizationHeaderValue = "Basic " + encodedValue;
    requestContent.Headers.Add("Authorization", authorizationHeaderValue);
