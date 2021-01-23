    [HttpPost]
    public ActionResult InternationalTransportationAddDetails(WorkOrderDetailsViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ViewData["wo_id"] = wo_id;  // however you get wo_id
        return View(model);
      }
      // if valid, process model here
    }
