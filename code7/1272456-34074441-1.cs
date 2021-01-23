    public ActionResult CreateTicket(int id)
    {
        var vm = new CreateTicketVm {EventId = id};
        vm.Tickets.Add(new TicketVm());
               
        return View(vm);
    }
