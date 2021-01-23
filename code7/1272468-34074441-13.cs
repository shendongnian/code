    [HttpPost]
    public ActionResult CreateTicket([FromBody] CreateTicketVm model)
    {
        if (model != null)
        {
           //check model.Tickets and model.EventId
           // to do : Save Tickets for the event
            return new JsonResult( new { Status ="Success"});
        }
        return new JsonResult( new { Status ="Error"});
    }
