    private string GetUrlTitle(Uri uri)
    {
        string title = "";
    
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(uri).Result;
    
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
                                    
            var contentStream = response.Content.ReadAsStreamAsync().Result;
            var charset = response.Content.Headers.ContentType.CharSet ?? GetCharsetFromBody(contentStream);                
    
            Encoding encoding = GetEncodingOrDefaultToUTF8(charset);
            string content = GetContent(contentStream, encoding);
    
            Match titleMatch = Regex.Match(content, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase);
    
            if (titleMatch.Success)
            {
                title = titleMatch.Groups["Title"].Value;
    
                // decode the title in case it have been encoded
                title = WebUtility.HtmlDecode(title).Trim();
            }
        }
    
        if (string.IsNullOrWhiteSpace(title))
        {
            title = uri.ToString();
        }
    
        return title;
    }
    
    private string GetContent(Stream contentStream, Encoding encoding)
    {
        contentStream.Seek(0, SeekOrigin.Begin);
    
        using (StreamReader sr = new StreamReader(contentStream, encoding))
        {
            return sr.ReadToEnd();
        }
    }
    
    /// <summary>
    /// Try getting the charset from the body content.
    /// </summary>
    /// <param name="contentStream"></param>
    /// <returns></returns>
    private string GetCharsetFromBody(Stream contentStream)
    {
        contentStream.Seek(0, SeekOrigin.Begin);
    
        StreamReader srr = new StreamReader(contentStream, Encoding.ASCII);
        string body = srr.ReadToEnd();
        string charset = null;
    
        if (body != null)
        {
            //find expression from : http://stackoverflow.com/questions/3458217/how-to-use-regular-expression-to-match-the-charset-string-in-html
            Match match = Regex.Match(body, @"<meta(?!\s*(?:name|value)\s*=)(?:[^>]*?content\s*=[\s""']*)?([^>]*?)[\s""';]*charset\s*=[\s""']*([^\s""'/>]*)", RegexOptions.IgnoreCase);
    
            if (match.Success)
            {
                charset = string.IsNullOrWhiteSpace(match.Groups[2].Value) ? null : match.Groups[2].Value;
            }
        }
    
        return charset;
    }
    
    /// <summary>
    /// Try parsing the charset or fallback to UTF8
    /// </summary>
    /// <param name="charset"></param>
    /// <returns></returns>
    private Encoding GetEncodingOrDefaultToUTF8(string charset)
    {
        Encoding e = Encoding.UTF8;
    
        if (charset != null)
        {
            try
            {
                e = Encoding.GetEncoding(charset);
            }
            catch
            {
            }
        }
    
        return e;
    }
