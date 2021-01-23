    // find in the html and return the three parameters in a string array
    // setCookie('YPF8827340282Jdskjhfiw_928937459182JAX666', '127.0.0.1', 10);
    private static string[] Parse(Stream _stream, string encoding)
    {
        const string setCookieCall = "setCookie('";
    
        // copy html as string
        var ms = new MemoryStream();
        _stream.CopyTo(ms);
        var html = Encoding.GetEncoding(encoding).GetString(ms.ToArray());
               
        // find setCookie call
        var findFirst = html.IndexOf(
            setCookieCall, 
            StringComparison.InvariantCultureIgnoreCase) + setCookieCall.Length;
        var last = html.IndexOf(");", findFirst, StringComparison.InvariantCulture);
                
        var setCookieStatmentCall = html.Substring(findFirst, last - findFirst);
        // take the parameters
        var parameters = setCookieStatmentCall.Split(new[] {','});
        for (int x = 0; x < parameters.Length; x++)
        {
            // cleanup
            parameters[x] = parameters[x].Replace("'", "").Trim();
        }
        return parameters;
    }
