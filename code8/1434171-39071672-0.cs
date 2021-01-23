    [HttpGet]
    public ActionResult BookTicket(int ID)
    {
        ... // set you SelectLists as above
        // Initialize your model and set the Flightid property
        var model = new Tickets()
        {
            Flightid = ID
        };
        return View(model); // return the model to the view
    }
