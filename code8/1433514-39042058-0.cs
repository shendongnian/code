    var dict = new Dictionary<Type, HttpStatusCode>
    {
        { typeof(AuthenticationException), HttpStatusCode.Forbidden },
        // etc.
    }
    HttpStatusCode GetStatusCodeFromException(Exception e)
    {
        HttpStatusCode code;
        if (!dict.TryGetValue(e.GetType(), out code))
            code = // Whatever default value you want
        return code;
    }
