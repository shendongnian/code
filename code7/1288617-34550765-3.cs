    [HttpPost]
    public ActionResult View(LabelTotalSummaryVm model)
    {
          var e = yourDbContext.RepairOrders.FirstOrDefault(s=>s==Id);
          if(e!=null) 
          {       
             vm.SomeEditableProperty =model.SomeEditableProperty ;
             yourDbContext.Entry(e).State=EntityState.Modified;
             yourDbContext.SaveChanges();
             return RedirectToAction("SomeSuccess");
          }
          return View(vm);
    }
