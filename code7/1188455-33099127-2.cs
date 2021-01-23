	public string HandleErrorResponse(IRestRequest request, IRestResponse response)
	{
		string statusString = string.Format("{0} {1} - {2}", (int)response.StatusCode, response.StatusCode, response.StatusDescription);
		string errorString = "Response status: " + statusString;
		string resultMessage;
		if (!response.StatusCode.IsScuccessStatusCode())
		{
			if (string.IsNullOrWhiteSpace(resultMessage))
			{
				resultMessage = "An error occurred while processing the request: "
							  + response.StatusDescription;
			}
		}
		if (response.ErrorException != null)
		{
			if (string.IsNullOrWhiteSpace(resultMessage))
			{
				resultMessage = "An exception occurred while processing the request: "
							  + response.ErrorException.Message;
			}
			errorString += ", Exception: " + response.ErrorException;
		}
		
		// (other error handling here)
		_logger.ErrorFormat("Error response: {0}", errorString);
		
		return resultMessage;
	}
