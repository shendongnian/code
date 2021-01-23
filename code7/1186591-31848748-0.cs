    public string SignUp(Credentials credentials, string[] clientIds, int[] classIds)
    {
        var addToclassRequest = new AddClientsToClassesRequest
        {
            SourceCredentials = new SourceCredentials
            {
                SourceName = credentials.SourceName,
                Password = credentials.SourcePassword,
                SiteIDs = credentials.SiteId
            },
           ClientIDs = clientIds,
           ClassIDs = classIds,
           Test = false,
           //RequirePayment = false,
           //Waitlist = false,
           SendEmail = true
        };
        var c = _classService.AddClientsToClasses(addToclassRequest);
        return c.Message.ToString();
    }
