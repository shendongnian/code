    public ActionResult Accept(string id)
    {
        var request = UpdateRequest(id, RequestOutcome.Accept).Result;
    
        if (request != null)
        {
            var c = request.DateConcluded;
        }
    }
