    IEnumerable<string> values;
    string session = string.Empty;
    if (response.Headers.TryGetValues("X-BB-SESSION", out values))
    {
        session = values.FirstOrDefault();
    }
