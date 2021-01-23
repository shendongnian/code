    public ExternalResponse RunAskQuestionBasicQuery(ExternalRequest request, string innerTransId)
    {
        ExternalResponse resp = null;
        ExternalTestSoapClient client = new ExternalTestSoapClient("ExternalTestSoap12");
        Logger.GetInstance().Log(innerTransId, "ExternalTestSoapClient created.");
        try
        {
            Logger.GetInstance().Log(innerTransId, "AskQuestion() calling...");
            resp = client.AskQuestion(request.SearchNumber, User, Password);
            Logger.GetInstance().Log(innerTransId, "AskQuestion() called.");           
            return resp;
        }
        catch (CommunicationException)
        {
            client.Abort();
            resp = null;
            SetError(bvResp, "External service is not accessible.");
            Logger.GetInstance().Log(innerTransId, "ExternalTestSoapClient aborted [CommunicationException].");
        }
        catch (TimeoutException)
        {
            client.Abort();
            resp = null;
            SetError(bvResp, "External service is not accessible.");
            Logger.GetInstance().Log(innerTransId, "ExternalTestSoapClient aborted [TimeoutException].");
        }
        catch (Exception ex)
        {
            Logger.GetInstance().Log(innerTransId, ex.Message);
            throw;
        }
        finally
        {
            if (client.State == CommunicationState.Opened)
            {
                client.Close();
                Logger.GetInstance().Log(innerTransId, "ExternalTestSoapClient closed.");
            }
        }
    }
