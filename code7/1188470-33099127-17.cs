    if (response.Data != null && !string.IsNullOrWhiteSpace(response.Data.ResultMessage))
    {
        resultMessage = response.Data.ResultMessage;
        errorString += string.Format(", Service response: \"{0}\"", response.Data.ResultMessage);
    }
