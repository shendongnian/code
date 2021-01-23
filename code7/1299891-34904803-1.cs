    public ActionResult Details(int id)
    {
       var vm = new StudentDetailVm { Id = id,
                                     Value = new StudentVm { 
                                                            StudentName = "Scott", 
                                                            Age = 23}};
      return View(vm);
    }
