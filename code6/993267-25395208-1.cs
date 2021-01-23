    HttpWebResponse resp = ...;
    StringBuilder responseText = new StringBuilder();
    responseText .AppendFormat("HTTP/{0}.{1} {2} {3}", resp.ProtocolVersion.Major, resp.ProtocolVersion.Minor, (int)resp.StatusCode, resp.StatusDescription);
    responseText .AppendLine();
    foreach (var header in resp.Headers)
    {
        responseText .AppendFormat("{0}: {1}", v, resp.Headers[v]);
        responseText .AppendLine();
    }
    responseText.AppendLine();
