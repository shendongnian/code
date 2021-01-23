    private static void HandleValidationError(ILogger logger, HttpRequestMessage requestMessage, HttpStatusCode statusCode, string message)
        {
            logger.LogError(LoggingSources.API, message);
            using (var errorResponse = requestMessage.CreateErrorResponse(statusCode, message))
    		{
    			throw new HttpResponseException(errorResponse);
    		}
        }    
