    public ActionResult Edit(int id)
    {
      var objVisitorsviewModel = new VisitorsViewModel();
      // I am hard coding to 25. 
      // You may replace it with a valid Employee Id from your db table for the record
      ObjVisitorsviewModel.EmployeeID= 25; 
      return View(objVisitorsviewModel);
    }
