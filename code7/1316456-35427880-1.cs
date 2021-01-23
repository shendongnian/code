    foreach (string key in webResponse.Headers.Keys)
    {
        if (key != "Location")
        {
            var value = webResponse.Headers[key];
            headers.Add(key, value);
        }
    }
