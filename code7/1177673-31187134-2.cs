    private static void HandleValidationError(ILogger logger, HttpRequestMessage requestMessage, HttpStatusCode statusCode, string message)
    {
        logger.LogError(LoggingSources.API, message);
        throw new HttpResponseException(new HttpResponseMessage(statusCode){
            ReasonPhrase = message
        });
    }
