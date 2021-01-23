    protected static JSonErrorResult JsonError(StatusCodes statusCode,
                                               string error, string message)
    {
        return new JsonErrorResult(statusCode, new 
        {
            StatusCode = Convert.ToString((int)statusCode),
            Error = error,
            Message = message
        });
    }
