    public ActionResult AddNewTicketRow()
    {
        var vm = new TicketVm ();
        return PartialView("~/Views/Home/Partials/AddNewTicketRow.cshtml", vm);
    }
