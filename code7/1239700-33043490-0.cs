    public static void apiCall(string yourCredentials, Action sendSuccess, Action sendAlert)
    {
        try
        {
            DoSomething();
            sendSuccess()
        }
        catch
        {
            sendAlert();
        }
    }
