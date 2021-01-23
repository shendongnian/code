    using(StreamReader streamReader = new StreamReader(responseStream))
    {
        char[] responseContentChars = new char[ResponseContentMaxLength];
                        streamReader.Read(responseContentChars, 0, ResponseContentMaxLength);
        string responseContentString = new string(responseContentChars);
        responseContent = responseContentString.Replace("\0", string.Empty);
    }
