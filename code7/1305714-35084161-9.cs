    protected static JSonResult JsonError(StatusCodes statusCode,
                                               string error, string message)
    {
        var result = new JsonResult(new 
        {
            StatusCode = Convert.ToString((int)statusCode),
            Error = error,
            Message = message
        });
        result.StatusCode = (int)statusCode;
        return result;
    }
