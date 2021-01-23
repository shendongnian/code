    public HttpResponseMessage GetAllNotificationSettings()
    {
        var result = new List<ListItems>();
        // Filling the list with data here...
    
        // Then I return the list
        return Request.CreateResponse(HttpStatusCode.OK, result);
    }
