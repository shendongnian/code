    var client = new MyServiceClient();
    try
    {
        client.Open();
        client.MyServiceCall();
        client.Close();
    }
    catch (CommunicationException e)
    {
        ...
        client.Abort();
    }
    catch (TimeoutException e)
    {
        ...
        client.Abort();
    }
    catch (Exception e)
    {
        ...
        client.Abort();
        throw;
    }
