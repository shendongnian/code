    [Route("api/tickets")]
    public HttpResponseMessage Post([FromBody]JObject newTicket)
    {
        var t = newTicket.ToObject<Ticket>();
        TicketsRepository.InsertTicket(t);
        HttpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
        return response;
    }
