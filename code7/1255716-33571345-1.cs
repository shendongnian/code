    private async Task<string> ResponseMessageAsync(HttpResponseMessage result)
    {
        string message = await result.Content.ReadAsStringAsync();
        string parsedString = Regex.Unescape(message);
        byte[] isoBites = Encoding.GetEncoding("ISO-8859-1").GetBytes(parsedString);
        return Encoding.UTF8.GetString(isoBites, 0, isoBites.Length);
     }
