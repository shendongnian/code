    public async Task<string> GetData(string query)
    {
        var result = string.Empty;
        try
        {
            var KnownHttpVerbType = typeof(System.Net.AuthenticationManager).Assembly.GetTypes().Where(t => t.Name == "KnownHttpVerb").First();
            var getVerb = KnownHttpVerbType.GetField("Get", BindingFlags.NonPublic | BindingFlags.Static);
            var ContentBodyNotAllowedField = KnownHttpVerbType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance);
            ContentBodyNotAllowedField.SetValue(getVerb.GetValue(null), false);
            var msg = new HttpRequestMessage(HttpMethod.Get, _dataApiUrl) { Content = new StringContent(query) };
            var response = await _httpClient.SendAsync(msg).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            result = await response.Content.ReadAsStringAsync();
        }
        catch (Exception exc)
        {
            _logger.ErrorException("Something broke in GetData(). Probably a borked connection.", exc);
        }
        return result;
    }
