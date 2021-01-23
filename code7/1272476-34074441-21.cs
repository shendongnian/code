    [HttpPost]
    public ActionResult CreateTicket(CreateTicketVm model)
    {
        if (model != null)
        {
            //check model.Tickets and model.EventId
            // to do : Save Tickets for the event
            return Json(new {Status = "Success"});
        }
        return Json(new {Status = "Error"});
    }
