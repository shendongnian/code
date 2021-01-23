    [HttpGet]
    public ActionResult FillOut ( Guid pid )
    {
      var vm= new FillOutVm { Pid=pid };
      return View(vm);
    }
