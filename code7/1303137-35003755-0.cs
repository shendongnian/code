    private async Task<XPathNavigator> UspsCreateAndPostRequest(string sUrl)
    {
      HttpClient client = new HttpClient();
      byte[] urlContents = await client.GetByteArrayAsync(sUrl).ConfigureAwait(false);
      string sResponse = System.Text.Encoding.UTF8.GetString(urlContents);
      ... //more code to return XPathNavigator object based on response
    }
