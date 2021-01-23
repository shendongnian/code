    private HttpResponseException CreateHttpResponseException(Exception ex)
    {
        HttpResponseMessage message;
        if (ex.GetType() == typeof(FaultException<LoginFault>))
        {
            message = new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
        else
        {
            message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    
        message.Content = new StringContent(ex.Message);
        return new HttpResponseException(message);
    }
