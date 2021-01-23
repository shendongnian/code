    public HttpResponseMessage Post()
    {
        var result = Authentication.GetAuthBehaviour();
        var valid = result as Types.AuthenticationResponse.Valid;
        if (valid != null)
        {
            int statusCode = valid.Item1;
            Types.ValidResponse body = valid.Item2;
            return this.CreateResponse(statusCode, body);
        }
        var error = result as Types.AuthenticationResponse.Error;
        if (error != null)
        {
            int statusCode = error.Item1;
            Types.ErrorResponse body = error.Item2;
            return this.CreateResponse(statusCode, body);
        }
        throw new InvalidOperationException("...");
    }
