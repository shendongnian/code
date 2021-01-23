    public async Task<Result> evaluate(Uri resourceUri, Func<JObject, Result> action)
    {
        try
        {
            responsefromUri = await requestManager.Post(resourceUri, "");
        }
            // The non-retryable exception will directly trickle up.
        catch (RetryableException exception)
        {
            return BuildFailedCheckResult(
                StatusCode.Abandoned,
                Check1 + " abandoned. Failed to read the response for resource: " + resourceUri + " with exception: " + exception.Message);
        }
        if (string.IsNullOrEmpty(responsefromUri))
        {
            return BuildFailedCheckResult(
                StatusCode.Failed,
                Check1 + " failed. Empty response for resource: " + resourceUri);
        }
        try
        {
            responseJson = JObject.Parse(responsefromUri);
        }
        catch (JsonReaderException e)
        {
            throw new InvalidOperationException(Check1 + " check failed parsing resource: " + resourceUri, e);
        }
        
        return action(responseJson);
    }
