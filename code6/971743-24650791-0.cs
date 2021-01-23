    // Catch the cookie name and value with using regex, than remove the
    // characters what we only need for the regex match.
    
    string cookieName = Regex.Match(data, "'[a-z]*").Value.Remove(0, 1);
    string cookieValue = Regex.Match(data, "=[a-zA-Z0-9]*").Value.Remove(0, 1);
    webRequest.CookieContainer.Add(new Cookie(cookieName,cookieValue));
    webResponse = webRequest.GetResponse() as HttpWebResponse;
    StreamReader sr2 = new StreamReader(webResponse.GetResponseStream(), Encoding.ASCII);
    string data = sr2.ReadToEnd();
