    var userName = "username@contoso.onmicrosoft.com";
    var password = "password";
    var payload = "{ '__metadata': { 'type': 'SP.Data.TasksListItem' }, 'Title': 'New Tasl'}";  //for a Task Item
    try
    {
        var claimshelper = new MsOnlineClaimsHelper(baseUrl, _userName, _password);
        var request = (HttpWebRequest)WebRequest.Create(baseUrl + "/" + endpointUrl);
        request.CookieContainer = claimshelper.CookieContainer;
        request.Headers.Add("X-RequestDigest", claimshelper.FormDigest);
        request.Method = "POST";
        request.Headers.Add("X-HTTP-Method", "MERGE");
        request.Headers.Add("If-Match", "*");
        request.Accept = "application/json;odata=verbose";
        request.ContentType = "application/json;odata=verbose";
        using (var writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write(payload);
            writer.Flush();
        }
        var response = request.GetResponse() as HttpWebResponse;
        //...
     }
     catch (Exception ex)
     {
        //Error handling goes here.. 
     }
