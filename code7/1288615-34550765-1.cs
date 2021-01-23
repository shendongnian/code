    public ActionResult View(int id)
    {
      var vm = new LabelTotalSummaryVm { Id=id };
      var e = yourDbContext.RepairOrders.FirstOrDefault(s=>s==Id);
      if(e!=null) 
      {
         vm.LaborTotal =e.LaborTotal ;
         vm.SomeEditableProperty =e.SomeEditableProperty ;
      }
      return View(vm);
    }
