    [HttpPost]
    public ActionResult InternationalTransportationAddDetails(SomeModel model)
    {
      if (!ModelState.IsValid)
      {
        ViewData["wo_id"] = wo_id;
        var viewmodel = new AEO.WorkOrder.Domain.ViewModels.WorkOrderDetailsViewModel(wo_id);
        viewmodel.comments = model.Comments;
        return View(viewmodel);
      }
